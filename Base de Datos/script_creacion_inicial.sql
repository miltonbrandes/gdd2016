use GD2C2016
go

create schema esquema authorization gd
go

/*		PLAN		*/

create table esquema.plan_medico (
	 plan_id numeric(18,0) primary key, 
	 plan_descripcion varchar(255),
	 plan_precio_bono_consulta numeric(18,0),
	 plan_cuota_precio numeric(18,0)		--	es necesario?
)
go

insert into esquema.plan_medico
(plan_id, plan_descripcion, plan_precio_bono_consulta)
select Plan_Med_Codigo, Plan_Med_Descripcion, Plan_Med_Precio_Bono_Consulta 
	from gd_esquema.Maestra
	group by Plan_Med_Codigo, Plan_Med_Descripcion, Plan_Med_Precio_Bono_Consulta
go


/*		AFILIADO		*/

create table esquema.afiliado (
	 afiliado_nro numeric(18,0) identity(101,100) primary key, 
	 afiliado_nombre varchar(255),
	 afiliado_apellido varchar(255),
	 afiliado_dni numeric(18,0),
	 afiliado_estado_civil character(1),	-- C, S, V, D, O:concubinato, N:no especificado
	 afiliado_sexo character(1),			-- M, F, N:no especificado
	 afiliado_fecha_nac datetime,
	 afiliado_telefono numeric(18,0),
	 afiliado_mail varchar(255),
	 afiliado_direccion varchar(255),
	 afiliado_cant_hijos numeric(2,0),
	 afiliado_plan numeric(18,0) foreign key references esquema.plan_medico(plan_id),
	 afiliado_habilitado numeric(2,0),
	 afiliado_cant_bonos_consulta numeric(18,0)
)
go

create trigger aumentar_cantidad_hijos on esquema.afiliado for insert
as
Begin
	declare @afiliado_nro numeric(18,0)
	select @afiliado_nro = afiliado_nro from inserted
	set @afiliado_nro = ROUND(@afiliado_nro / 100, 0)

	update esquema.afiliado set afiliado_cant_hijos = afiliado_cant_hijos + 1
		where ROUND(afiliado_nro/100, 0) = @afiliado_nro
		and afiliado_nro - 1 = ROUND(afiliado_nro/100, 0)*100
End
go

create trigger reducir_cantidad_hijos on esquema.afiliado for delete
as
Begin
	declare @afiliado_nro numeric(18,0)
	select @afiliado_nro = afiliado_nro from deleted
	set @afiliado_nro = ROUND(@afiliado_nro / 100, 0)

	update esquema.afiliado set afiliado_cant_hijos = afiliado_cant_hijos - 1
		where ROUND(afiliado_nro/100, 0) = @afiliado_nro
		and afiliado_nro - 1 = ROUND(afiliado_nro/100, 0)*100		--
End
go


insert into esquema.afiliado
(afiliado_nombre, afiliado_apellido, afiliado_dni, afiliado_estado_civil, 
afiliado_sexo, afiliado_fecha_nac, afiliado_telefono, afiliado_mail, afiliado_direccion, afiliado_cant_hijos, afiliado_cant_bonos_consulta, afiliado_plan)
select Paciente_Nombre, Paciente_Apellido, Paciente_Dni, 'N', 'N', Paciente_Fecha_Nac, Paciente_Telefono, Paciente_Mail, Paciente_Direccion, 0, 0, Plan_Med_Codigo 
	from gd_esquema.Maestra
	group by Paciente_Nombre, Paciente_Apellido, Paciente_Dni, Paciente_Fecha_Nac, Paciente_Telefono, Paciente_Mail, Paciente_Direccion, Plan_Med_Codigo
go

/*		BONOS		*/

create table esquema.bono_consulta (
	 bono_id numeric(18,0) primary key, 
	 bono_afiliado numeric(18,0) foreign key references esquema.afiliado(afiliado_nro),
	 bono_plan numeric(18,0) foreign key references esquema.plan_medico(plan_id),
	 -- bono_turno numeric(18,0) foreign key references turno(turno_id),
	 bono_fecha_compra datetime,
	 bono_utilizado character(1)
)
go

insert into esquema.bono_consulta (bono_id, bono_afiliado, bono_plan, bono_fecha_compra)
select Bono_Consulta_Numero, afiliado_nro, Plan_Med_Codigo, Compra_Bono_Fecha
	from gd_esquema.Maestra, esquema.afiliado
	where Bono_Consulta_Numero is not null and Compra_Bono_Fecha is not null and afiliado_dni = Paciente_Dni
	order by Bono_Consulta_Numero, Paciente_Dni, Plan_Med_Codigo, Compra_Bono_Fecha
go



SET NOCOUNT ON 
go

create procedure esquema.contarBonos
as
Begin
	declare @afiliado numeric(18,0)
	declare unCursor cursor for select afiliado_nro from esquema.afiliado
	open unCursor
	fetch next from unCursor into @afiliado
	while @@FETCH_STATUS = 0
	Begin
		update esquema.afiliado set afiliado_cant_bonos_consulta = (select count(*) from esquema.bono_consulta where bono_afiliado = @afiliado)
			where afiliado_nro = @afiliado
		fetch next from unCursor into @afiliado
	End
	close unCursor
	deallocate unCursor
End
go

exec esquema.contarBonos		-- comentar esto para q no tarde
go


create trigger aumentar_cantidad_bonos_afiliado on esquema.bono_consulta after insert
as
Begin
	declare @bono_afiliado numeric(18,0)
	if (select count(*) from inserted) = 1
	Begin
		select @bono_afiliado = bono_afiliado from inserted
		update esquema.afiliado set afiliado_cant_bonos_consulta = afiliado_cant_bonos_consulta + 1
				where afiliado_nro = @bono_afiliado
	End
End
go

/*		MODIFICACION DE PLAN		*/

create table esquema.modificacion_plan (
	 modif_id numeric(18,0) identity(1,1) primary key,
	 modif_afiliado numeric(18,0) foreign key references esquema.afiliado(afiliado_nro),
	 modif_plan_viejo numeric(18,0) foreign key references esquema.plan_medico(plan_id),
	 modif_plan_nuevo numeric(18,0) foreign key references esquema.plan_medico(plan_id),
	 modif_plan_fecha datetime,
	 modif_motivo varchar(255)		-- como necesito un motivo no lo registro con un trigger
)
go
