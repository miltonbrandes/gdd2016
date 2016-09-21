use GD2C2016
go

create schema esquema authorization gd
go

/*USUARIO*/
CREATE TABLE esquema.usuario(
	usuario_id varchar(50) NOT NULL,
	usuario_password varchar(300) NULL,
	usuario_descripcion varchar(50) NULL,
	usuario_habilitado bit NULL,
	usuario_cant_intentos int NULL,
 CONSTRAINT [PK_esquema.usuario] PRIMARY KEY CLUSTERED 
(
	[usuario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/*FUNCION*/
CREATE TABLE esquema.funcion(
	funcion_id int NOT NULL,
	funcion_descripcion varchar(50) NULL,
 CONSTRAINT [PK_funcion] PRIMARY KEY CLUSTERED 
(
	[funcion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/*ROL*/
CREATE TABLE esquema.rol(
	rol_id int NOT NULL,
	rol_descripcion varchar(50) NULL,
	rol_habilitado bit NOT NULL,
 CONSTRAINT [PK_rol] PRIMARY KEY CLUSTERED 
(
	[rol_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/*FUNCION X ROL*/
CREATE TABLE esquema.funcionXrol(
	rol_id int NOT NULL,
	funcion_id int NOT NULL,
 CONSTRAINT [PK_esquema.funcionXrol] PRIMARY KEY CLUSTERED 
(
	[rol_id] ASC,
	[funcion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE esquema.funcionXrol  WITH CHECK ADD  CONSTRAINT [FK_esquema.funcionXrol_funcion] FOREIGN KEY([funcion_id])
REFERENCES [esquema].[funcion] ([funcion_id])
GO

ALTER TABLE esquema.funcionXrol CHECK CONSTRAINT [FK_esquema.funcionXrol_funcion]
GO

ALTER TABLE esquema.funcionXrol  WITH CHECK ADD  CONSTRAINT [FK_esquema.funcionXrol_rol] FOREIGN KEY([rol_id])
REFERENCES [esquema].[rol] ([rol_id])
GO

ALTER TABLE esquema.funcionXrol CHECK CONSTRAINT [FK_esquema.funcionXrol_rol]
GO

/*ROL X USUARIO*/
CREATE TABLE esquema.rolXusuario(
	rol_id int NOT NULL,
	usuario_id varchar(50) NOT NULL,
 CONSTRAINT [PK_esquema.rolXusuario] PRIMARY KEY CLUSTERED 
(
	[rol_id] ASC,
	[usuario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE esquema.rolXusuario WITH CHECK ADD  CONSTRAINT [FK_esquema.rolXusuario_rol] FOREIGN KEY([rol_id])
REFERENCES [esquema].[rol] ([rol_id])
GO

ALTER TABLE esquema.rolXusuario CHECK CONSTRAINT [FK_esquema.rolXusuario_rol]
GO

ALTER TABLE esquema.rolXusuario  WITH CHECK ADD  CONSTRAINT [FK_esquema.rolXusuario_usuario] FOREIGN KEY([usuario_id])
REFERENCES [esquema].[usuario] ([usuario_id])
GO

ALTER TABLE esquema.rolXusuario CHECK CONSTRAINT [FK_esquema.rolXusuario_usuario]
GO

/*TIPO ESPECIALIDAD*/
CREATE TABLE esquema.tipo_especialidad(
	tipo_especialidad_codigo numeric(18,0) NOT NULL,
	tipo_especialidad_descripcion varchar(255) NULL,
 CONSTRAINT [PK_tipo_especialidad] PRIMARY KEY CLUSTERED 
(
	[tipo_especialidad_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

insert into esquema.tipo_especialidad
(tipo_especialidad_codigo, tipo_especialidad_descripcion)
select Tipo_Especialidad_Codigo, Tipo_Especialidad_Descripcion
	from gd_esquema.Maestra
	where Tipo_Especialidad_Codigo is not null
	group by Tipo_Especialidad_Codigo, Tipo_Especialidad_Descripcion
go

/*ESPECIALIDAD*/
CREATE TABLE esquema.especialidad(
	especialidad_codigo numeric(18, 0) NOT NULL,
	especialidad_descripcion varchar(255) NULL,
	especialidad_tipo numeric(18, 0) NULL,
 CONSTRAINT [PK_especialidad] PRIMARY KEY CLUSTERED 
(
	[especialidad_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE esquema.especialidad  WITH CHECK ADD  CONSTRAINT [FK_especialidad_tipo_especialidad1] FOREIGN KEY([especialidad_tipo])
REFERENCES esquema.tipo_especialidad ([tipo_especialidad_codigo])
GO

ALTER TABLE esquema.especialidad CHECK CONSTRAINT [FK_especialidad_tipo_especialidad1]
GO

insert into esquema.especialidad
(especialidad_codigo, especialidad_descripcion, especialidad_tipo)
select Especialidad_Codigo, Especialidad_Descripcion, Tipo_Especialidad_Codigo
	from gd_esquema.Maestra
	where Especialidad_Codigo is not null
	group by Especialidad_Codigo, Especialidad_Descripcion, Tipo_Especialidad_Codigo
go

/*PROFESIONAL*/

CREATE TABLE [esquema].[profesional](
	[profesional_matricula] [int] IDENTITY(10,10) NOT NULL, --autoincremental de 10 en 10
	[usuario_id] [varchar](50) NULL,
	[profesional_nombre] [varchar](50) NULL,
	[profesional_apellido] [varchar](50) NULL,
	[profesional_dni] [numeric](8, 0) NULL,
	[profesional_tipo_doc] [char](1) NULL, --D por defecto = dni, otros a ver
	[profesional_telefono] [varchar](20) NULL,
	[profesional_mail] [varchar](50) NULL,
	[profesional_direccion] [varchar](50) NULL,
	[profesional_sexo] [char](1) NULL, --inicialmente en N por no identificado, en general F o M
	[profesional_fecha_nacimiento] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[profesional_matricula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [esquema].[profesional]  WITH CHECK ADD  CONSTRAINT [FK_profesional_usuario] FOREIGN KEY([usuario_id])
REFERENCES [esquema].[usuario] ([usuario_id])
GO

ALTER TABLE [esquema].[profesional] CHECK CONSTRAINT [FK_profesional_usuario]
GO

insert into esquema.profesional
(profesional_nombre, profesional_apellido, profesional_dni, profesional_direccion, profesional_telefono, profesional_mail, profesional_fecha_nacimiento, profesional_sexo, profesional_tipo_doc)
select Medico_Nombre, Medico_Apellido, Medico_Dni, Medico_Direccion, Medico_Telefono, Medico_Mail, Medico_Fecha_Nac, 'N', 'D' 
	from gd_esquema.Maestra
	where Medico_Nombre <> 'NULL'
	group by Medico_Nombre, Medico_Apellido, Medico_Dni, Medico_Direccion, Medico_Telefono, Medico_Mail, Medico_Fecha_Nac 
go

/*MEDICO X ESPECIALIDAD*/
CREATE TABLE esquema.medicoXespecialidad(
	medxesp_id int IDENTITY(1,1) NOT NULL,
	profesional_matricula int NOT NULL,
	especialidad_id numeric(18, 0) NOT NULL,
	agenda_id int NULL,
 CONSTRAINT [PK_esquema.medicoXespecialidad] PRIMARY KEY CLUSTERED 
(
	[medxesp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE esquema.medicoXespecialidad  WITH CHECK ADD  CONSTRAINT [FK_esquema.medicoXespecialidad_especialidad] FOREIGN KEY([especialidad_id])
REFERENCES [esquema].[especialidad] ([especialidad_codigo])
GO

ALTER TABLE esquema.medicoXespecialidad CHECK CONSTRAINT [FK_esquema.medicoXespecialidad_especialidad]
GO

ALTER TABLE esquema.medicoXespecialidad  WITH CHECK ADD  CONSTRAINT [FK_esquema.medicoXespecialidad_profesional] FOREIGN KEY([profesional_matricula])
REFERENCES [esquema].[profesional] ([profesional_matricula])
GO

ALTER TABLE esquema.medicoXespecialidad CHECK CONSTRAINT [FK_esquema.medicoXespecialidad_profesional]
GO

insert into esquema.medicoXespecialidad (profesional_matricula, especialidad_id) 
select profesional_matricula, Especialidad_Codigo
	from gd_esquema.Maestra, esquema.profesional
	where Medico_Nombre = profesional_nombre and Medico_Dni = profesional_dni
	group by profesional_matricula, Especialidad_Codigo
	order by profesional_matricula
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

/*INTENTOS USUARIO*/
CREATE PROCEDURE esquema.Usuario_SumarIntento (@Username varchar(50))
AS
BEGIN
  UPDATE esquema.usuario
  SET usuario_cant_intentos = usuario_cant_intentos + 1
  WHERE usuario_id = @Username
END
GO

CREATE PROCEDURE esquema.Usuario_ResetearIntentos (@Username varchar(50))
AS
BEGIN
  UPDATE esquema.usuario
  SET usuario_cant_intentos = 0
  WHERE usuario_cant_intentos = @Username
END
GO

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
