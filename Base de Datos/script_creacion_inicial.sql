use GD2C2016
go

create schema NOT_NULL authorization gd
go

/*USUARIO*/
CREATE TABLE NOT_NULL.usuario(
	usuario_id varchar(50) NOT NULL,
	usuario_password varchar(300) NULL,
	usuario_descripcion varchar(50) NULL,
	usuario_habilitado bit NULL,
	usuario_cant_intentos int NULL,
 CONSTRAINT [PK_NOT_NULL.usuario] PRIMARY KEY CLUSTERED 
(
	[usuario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/*FUNCION*/
CREATE TABLE NOT_NULL.funcion(
	funcion_id int NOT NULL IDENTITY(1,1),
	funcion_descripcion varchar(50) NULL,
 CONSTRAINT [PK_funcion] PRIMARY KEY CLUSTERED 
(
	[funcion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/*ROL*/
CREATE TABLE NOT_NULL.rol(
	rol_id int NOT NULL IDENTITY(1,1),
	rol_descripcion varchar(50) NULL,
	rol_habilitado bit NOT NULL default(1),
 CONSTRAINT [PK_rol] PRIMARY KEY CLUSTERED 
(
	[rol_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
Insert INTO NOT_NULL.Rol(rol_descripcion)
  VALUES ('Administrador'), ('Afiliado'), ('Profesional')
GO

/*FUNCION X ROL*/
CREATE TABLE NOT_NULL.funcionXrol(
	rol_id int NOT NULL,
	funcion_id int NOT NULL,
	funcionXrol_activo bit NOT NULL default(1)
 CONSTRAINT [PK_NOT_NULL.funcionXrol] PRIMARY KEY CLUSTERED 
(
	[rol_id] ASC,
	[funcion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE NOT_NULL.funcionXrol  WITH CHECK ADD  CONSTRAINT [FK_NOT_NULL.funcionXrol_funcion] FOREIGN KEY([funcion_id])
REFERENCES [NOT_NULL].[funcion] ([funcion_id])
GO

ALTER TABLE NOT_NULL.funcionXrol CHECK CONSTRAINT [FK_NOT_NULL.funcionXrol_funcion]
GO

ALTER TABLE NOT_NULL.funcionXrol  WITH CHECK ADD  CONSTRAINT [FK_NOT_NULL.funcionXrol_rol] FOREIGN KEY([rol_id])
REFERENCES [NOT_NULL].[rol] ([rol_id])
GO

ALTER TABLE NOT_NULL.funcionXrol CHECK CONSTRAINT [FK_NOT_NULL.funcionXrol_rol]
GO

/*ROL X USUARIO*/
CREATE TABLE NOT_NULL.rolXusuario(
	rol_id int NOT NULL,
	usuario_id varchar(50) NOT NULL,
	rolXusuario_habilitado bit NOT NULL default(1),
 CONSTRAINT [PK_NOT_NULL.rolXusuario] PRIMARY KEY CLUSTERED 
(
	[rol_id] ASC,
	[usuario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE NOT_NULL.rolXusuario WITH CHECK ADD  CONSTRAINT [FK_NOT_NULL.rolXusuario_rol] FOREIGN KEY([rol_id])
REFERENCES [NOT_NULL].[rol] ([rol_id])
GO

ALTER TABLE NOT_NULL.rolXusuario CHECK CONSTRAINT [FK_NOT_NULL.rolXusuario_rol]
GO

ALTER TABLE NOT_NULL.rolXusuario  WITH CHECK ADD  CONSTRAINT [FK_NOT_NULL.rolXusuario_usuario] FOREIGN KEY([usuario_id])
REFERENCES [NOT_NULL].[usuario] ([usuario_id])
GO

ALTER TABLE NOT_NULL.rolXusuario CHECK CONSTRAINT [FK_NOT_NULL.rolXusuario_usuario]
GO

/*TIPO ESPECIALIDAD*/
CREATE TABLE NOT_NULL.tipo_especialidad(
	tipo_especialidad_codigo numeric(18,0) NOT NULL,
	tipo_especialidad_descripcion varchar(255) NULL,
 CONSTRAINT [PK_tipo_especialidad] PRIMARY KEY CLUSTERED 
(
	[tipo_especialidad_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

insert into NOT_NULL.tipo_especialidad
(tipo_especialidad_codigo, tipo_especialidad_descripcion)
select Tipo_Especialidad_Codigo, Tipo_Especialidad_Descripcion
	from gd_esquema.Maestra
	where Tipo_Especialidad_Codigo is not null
	group by Tipo_Especialidad_Codigo, Tipo_Especialidad_Descripcion
go

/*ESPECIALIDAD*/
CREATE TABLE NOT_NULL.especialidad(
	especialidad_codigo numeric(18, 0) NOT NULL,
	especialidad_descripcion varchar(255) NULL,
	especialidad_tipo numeric(18, 0) NULL,
 CONSTRAINT [PK_especialidad] PRIMARY KEY CLUSTERED 
(
	[especialidad_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE NOT_NULL.especialidad  WITH CHECK ADD  CONSTRAINT [FK_especialidad_tipo_especialidad1] FOREIGN KEY([especialidad_tipo])
REFERENCES NOT_NULL.tipo_especialidad ([tipo_especialidad_codigo])
GO

ALTER TABLE NOT_NULL.especialidad CHECK CONSTRAINT [FK_especialidad_tipo_especialidad1]
GO

insert into NOT_NULL.especialidad
(especialidad_codigo, especialidad_descripcion, especialidad_tipo)
select Especialidad_Codigo, Especialidad_Descripcion, Tipo_Especialidad_Codigo
	from gd_esquema.Maestra
	where Especialidad_Codigo is not null
	group by Especialidad_Codigo, Especialidad_Descripcion, Tipo_Especialidad_Codigo
go

/*PROFESIONAL*/

CREATE TABLE [NOT_NULL].[profesional](
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
ALTER TABLE [NOT_NULL].[profesional]  WITH CHECK ADD  CONSTRAINT [FK_profesional_usuario] FOREIGN KEY([usuario_id])
REFERENCES [NOT_NULL].[usuario] ([usuario_id])
GO

ALTER TABLE [NOT_NULL].[profesional] CHECK CONSTRAINT [FK_profesional_usuario]
GO


create trigger NOT_NULL.crear_usuario_profesional on NOT_NULL.profesional for insert
as
Begin
	--declare @afiliado_usuario varchar(50)
	insert into NOT_NULL.usuario (usuario_id, usuario_cant_intentos, usuario_descripcion, usuario_password, usuario_habilitado)
	select profesional_nombre + profesional_apellido + CAST(profesional_dni as varchar(8)), 0, 'Profesional',HASHBYTES('SHA2_256', 'profesional'), 1 from inserted where inserted.profesional_nombre is not null and inserted.profesional_apellido is not null and inserted.profesional_dni is not null
	insert into NOT_NULL.rolXusuario (usuario_id, rolXusuario_habilitado, rol_id)
	(select profesional_nombre + profesional_apellido + CAST(profesional_dni as varchar(8)), 1, 3 from inserted where profesional_nombre is not null and profesional_apellido is not null and profesional_dni is not null)
End
go


insert into NOT_NULL.profesional
(profesional_nombre, profesional_apellido, profesional_dni, profesional_direccion, profesional_telefono, profesional_mail, profesional_fecha_nacimiento, profesional_sexo, profesional_tipo_doc)
select Medico_Nombre, Medico_Apellido, Medico_Dni, Medico_Direccion, Medico_Telefono, Medico_Mail, Medico_Fecha_Nac, 'N', 'D' 
	from gd_esquema.Maestra
	where Medico_Nombre <> 'NULL'
	group by Medico_Nombre, Medico_Apellido, Medico_Dni, Medico_Direccion, Medico_Telefono, Medico_Mail, Medico_Fecha_Nac 
go

update NOT_NULL.profesional set NOT_NULL.profesional.usuario_id = profesional_nombre + profesional_apellido + cast(profesional_dni as varchar(8)) 
go

/*MEDICO X ESPECIALIDAD*/
CREATE TABLE NOT_NULL.medicoXespecialidad(
	medxesp_id int IDENTITY(1,1) NOT NULL,
	medxesp_profesional int NOT NULL,
	medxesp_especialidad numeric(18, 0) NOT NULL,
	medxesp_agenda int NULL,
 CONSTRAINT [PK_NOT_NULL.medicoXespecialidad] PRIMARY KEY CLUSTERED 
(
	[medxesp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE NOT_NULL.medicoXespecialidad  WITH CHECK ADD  CONSTRAINT [FK_NOT_NULL.medicoXespecialidad_especialidad] FOREIGN KEY(medxesp_especialidad)
REFERENCES [NOT_NULL].[especialidad] ([especialidad_codigo])
GO

ALTER TABLE NOT_NULL.medicoXespecialidad CHECK CONSTRAINT [FK_NOT_NULL.medicoXespecialidad_especialidad]
GO

ALTER TABLE NOT_NULL.medicoXespecialidad  WITH CHECK ADD  CONSTRAINT [FK_NOT_NULL.medicoXespecialidad_profesional] FOREIGN KEY(medxesp_profesional)
REFERENCES [NOT_NULL].[profesional] ([profesional_matricula])
GO

ALTER TABLE NOT_NULL.medicoXespecialidad CHECK CONSTRAINT [FK_NOT_NULL.medicoXespecialidad_profesional]
GO

insert into NOT_NULL.medicoXespecialidad (medxesp_profesional, medxesp_especialidad) 
select profesional_matricula, Especialidad_Codigo
	from gd_esquema.Maestra, NOT_NULL.profesional
	where Medico_Nombre = profesional_nombre and Medico_Dni = profesional_dni
	group by profesional_matricula, Especialidad_Codigo
	order by profesional_matricula
go

/*		PLAN		*/

create table NOT_NULL.plan_medico (
	 plan_id numeric(18,0) primary key, 
	 plan_descripcion varchar(255),
	 plan_precio_bono_consulta numeric(18,0),
	 plan_cuota_precio numeric(18,0)		--	es necesario?
)
go

insert into NOT_NULL.plan_medico
(plan_id, plan_descripcion, plan_precio_bono_consulta)
select Plan_Med_Codigo, Plan_Med_Descripcion, Plan_Med_Precio_Bono_Consulta 
	from gd_esquema.Maestra
	group by Plan_Med_Codigo, Plan_Med_Descripcion, Plan_Med_Precio_Bono_Consulta
go

/*		AFILIADO		*/

create table NOT_NULL.afiliado (
	 afiliado_nro numeric(18,0) identity(101,100) primary key, 
	 usuario_id varchar(50) NULL foreign key references NOT_NULL.usuario(usuario_id),
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
	 afiliado_plan numeric(18,0) foreign key references NOT_NULL.plan_medico(plan_id)
)
go


create trigger NOT_NULL.aumentar_cantidad_hijos on NOT_NULL.afiliado for insert
as
Begin
	declare @nro_afiliado numeric(18,0)
	select @nro_afiliado = afiliado_nro from inserted
	set @nro_afiliado = ROUND(@nro_afiliado / 100, 0)
	update NOT_NULL.afiliado set afiliado_cant_hijos = afiliado.afiliado_cant_hijos + 1
		where ROUND(afiliado.afiliado_nro/100, 0) = @nro_afiliado and afiliado_nombre <> 'admin'
		and afiliado.afiliado_nro = ROUND(afiliado.afiliado_nro/100, 0)*100 +1
			--and afiliado.afiliado_nro = ROUND(afiliado.afiliado_nro/100, 0)*100
End
go

create trigger NOT_NULL.reducir_cantidad_hijos on NOT_NULL.afiliado for delete
as
Begin
	declare @afiliado_nro numeric(18,0)
	select @afiliado_nro = afiliado_nro from deleted
	set @afiliado_nro = ROUND(@afiliado_nro / 100, 0)

	update NOT_NULL.afiliado set afiliado_cant_hijos = afiliado_cant_hijos - 1
		where ROUND(afiliado_nro/100, 0) = @afiliado_nro
		and afiliado_nro - 1 = ROUND(afiliado_nro/100, 0)*100		--
End
go


create trigger NOT_NULL.crear_usuario on NOT_NULL.afiliado instead of insert
as
	Begin
		declare @ultimoafiliado int
		set @ultimoafiliado = (select top 1 afiliado_nro from NOT_NULL.afiliado order by afiliado_nro desc);
		declare @ultimoCon1 int;
		set @ultimoCon1 = (select top 1 afiliado_nro from NOT_NULL.afiliado where RIGHT(afiliado_nro,1) = 1 order by afiliado_nro desc);
		if(RIGHT(@ultimoafiliado,1) = 1 or @ultimoafiliado is null)
		begin
			insert into NOT_NULL.usuario (usuario_id, usuario_cant_intentos, usuario_descripcion, usuario_password, usuario_habilitado)
			select afiliado_nombre + afiliado_apellido + CAST(afiliado_dni as varchar(8)), 0, 'Afiliado',HASHBYTES('SHA2_256', 'afiliado'), 1 from inserted where inserted.afiliado_nombre is not null and inserted.afiliado_apellido is not null and inserted.afiliado_dni is not null;
			insert into NOT_NULL.afiliado (usuario_id, afiliado_nombre, afiliado_apellido, afiliado_dni, afiliado_cant_hijos, afiliado_direccion, afiliado_estado_civil, afiliado_fecha_nac, afiliado_mail, afiliado_plan, afiliado_sexo, afiliado_telefono)
			(select afiliado_nombre + afiliado_apellido + CAST(afiliado_dni as varchar(8)), afiliado_nombre, afiliado_apellido, afiliado_dni, 0, afiliado_direccion, afiliado_estado_civil, afiliado_fecha_nac, afiliado_mail, afiliado_plan, afiliado_sexo, afiliado_telefono from inserted  
			where inserted.afiliado_nombre is not null and inserted.afiliado_apellido is not null and inserted.afiliado_dni is not null);
			insert into NOT_NULL.rolXusuario (rolXusuario_habilitado, rol_id, usuario_id) 
			(select 1, 2, afiliado_nombre + afiliado_apellido + CAST(afiliado_dni as varchar(8)) from inserted
			where inserted.afiliado_nombre is not null and inserted.afiliado_apellido is not null and inserted.afiliado_dni is not null)
		end
		else
		begin
			insert into NOT_NULL.usuario (usuario_id, usuario_cant_intentos, usuario_descripcion, usuario_password, usuario_habilitado)
			select afiliado_nombre + afiliado_apellido + CAST(afiliado_dni as varchar(8)), 0, 'Afiliado',HASHBYTES('SHA2_256', 'afiliado'), 1 from inserted where inserted.afiliado_nombre is not null and inserted.afiliado_apellido is not null and inserted.afiliado_dni is not null;
			SET IDENTITY_INSERT NOT_NULL.afiliado ON
			insert into NOT_NULL.afiliado (afiliado_nro,usuario_id, afiliado_nombre, afiliado_apellido, afiliado_dni, afiliado_cant_hijos, afiliado_direccion, afiliado_estado_civil, afiliado_fecha_nac, afiliado_mail, afiliado_plan, afiliado_sexo, afiliado_telefono)
			(select (@ultimoCon1+100), afiliado_nombre + afiliado_apellido + CAST(afiliado_dni as varchar(8)), afiliado_nombre, afiliado_apellido, afiliado_dni, 0, afiliado_direccion, afiliado_estado_civil, afiliado_fecha_nac, afiliado_mail, afiliado_plan, afiliado_sexo, afiliado_telefono from inserted  
			where inserted.afiliado_nombre is not null and inserted.afiliado_apellido is not null and inserted.afiliado_dni is not null);
			SET IDENTITY_INSERT NOT_NULL.afiliado OFF
			insert into NOT_NULL.rolXusuario (rolXusuario_habilitado, rol_id, usuario_id) 
			(select 1, 2, afiliado_nombre + afiliado_apellido + CAST(afiliado_dni as varchar(8)) from inserted
			where inserted.afiliado_nombre is not null and inserted.afiliado_apellido is not null and inserted.afiliado_dni is not null)
		end
	End
go

insert into NOT_NULL.afiliado
(afiliado_nombre, afiliado_apellido,  afiliado_dni, afiliado_estado_civil, 
afiliado_sexo, afiliado_fecha_nac, afiliado_telefono, afiliado_mail, afiliado_direccion, afiliado_cant_hijos, afiliado_plan)
select Paciente_Nombre, Paciente_Apellido,Paciente_Dni, 'N', 'N', Paciente_Fecha_Nac, Paciente_Telefono, Paciente_Mail, Paciente_Direccion, 0, Plan_Med_Codigo 
	from gd_esquema.Maestra
	group by Paciente_Nombre, Paciente_Apellido, Paciente_Dni, Paciente_Fecha_Nac, Paciente_Telefono, Paciente_Mail, Paciente_Direccion, Plan_Med_Codigo
go


create procedure NOT_NULL.Hijos_En_Cero(@username varchar(50))
as
	begin 
		update NOT_NULL.afiliado set afiliado_cant_hijos = 0 where usuario_id = @username
	end
go

update NOT_NULL.afiliado set usuario_id = afiliado_nombre + afiliado_apellido + cast(afiliado_dni as varchar(8))
go

update NOT_NULL.afiliado set afiliado_cant_hijos = 0
go

/*INTENTOS USUARIO*/
CREATE PROCEDURE NOT_NULL.Usuario_SumarIntento (@Username varchar(50))
AS
BEGIN
  UPDATE NOT_NULL.usuario
  SET usuario_cant_intentos = usuario_cant_intentos + 1
  WHERE usuario_id = @Username
END
GO

CREATE PROCEDURE NOT_NULL.Usuario_ResetearIntentos (@Username varchar(50))
AS
BEGIN
  UPDATE NOT_NULL.usuario
  SET usuario_cant_intentos = 0
  WHERE usuario_cant_intentos = @Username
END
GO
/* OBTENER UN USUARIO */
CREATE PROCEDURE NOT_NULL.Usuario_Get(@usuario varchar(20))
AS
BEGIN
  SET NOCOUNT ON;

  SELECT * FROM NOT_NULL.usuario WHERE usuario_id = @usuario
END
GO

/*		MODIFICACION DE PLAN		*/

create table NOT_NULL.modificacion_plan (
	 modif_id numeric(18,0) identity(1,1) primary key,
	 modif_afiliado numeric(18,0) foreign key references NOT_NULL.afiliado(afiliado_nro),
	 modif_plan_viejo numeric(18,0) foreign key references NOT_NULL.plan_medico(plan_id),
	 modif_plan_nuevo numeric(18,0) foreign key references NOT_NULL.plan_medico(plan_id),
	 modif_plan_fecha datetime,
	 modif_motivo varchar(255)		-- como necesito un motivo no lo registro con un trigger
)
go

/*			TURNOS			*/
CREATE TABLE NOT_NULL.turno(
	turno_nro numeric(18, 0) NOT NULL,
	afiliado_nro numeric(18, 0) NOT NULL,
	turno_fecha datetime NULL,
	turno_estado char(1) NULL,
	turno_hora_llegada datetime NULL,
	turno_sintomas varchar(255) NULL,
	turno_enfermedades varchar(255) NULL,
	turno_medico_especialidad_id int NULL,
	CONSTRAINT [PK_NOT_NULL.turno] PRIMARY KEY CLUSTERED 
	(turno_nro ASC)
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE NOT_NULL.turno  WITH CHECK ADD  CONSTRAINT [FK_NOT_NULL.turno_afiliado] FOREIGN KEY([afiliado_nro])
REFERENCES [NOT_NULL].[afiliado] ([afiliado_nro])
GO

ALTER TABLE NOT_NULL.turno CHECK CONSTRAINT [FK_NOT_NULL.turno_afiliado]
GO

ALTER TABLE NOT_NULL.turno  WITH CHECK ADD  CONSTRAINT [FK_NOT_NULL.turno_medicoXespecialidad] FOREIGN KEY([turno_medico_especialidad_id])
REFERENCES [NOT_NULL].[medicoXespecialidad] ([medxesp_id])
GO

ALTER TABLE NOT_NULL.turno CHECK CONSTRAINT [FK_NOT_NULL.turno_medicoXespecialidad]
GO

insert into NOT_NULL.turno(turno_nro, afiliado_nro, turno_fecha, turno_estado, turno_hora_llegada, turno_sintomas , turno_enfermedades, turno_medico_especialidad_id)
select Turno_Numero, afiliado_nro, Turno_Fecha, 'U', Bono_Consulta_Fecha_Impresion, Consulta_Sintomas, Consulta_Enfermedades, medxesp_id
	from gd_esquema.Maestra, NOT_NULL.afiliado, NOT_NULL.medicoXespecialidad, NOT_NULL.profesional
	where afiliado_dni = Paciente_Dni and medxesp_especialidad = Especialidad_Codigo and medXesp_profesional = profesional_matricula
		and profesional_dni = Medico_Dni
		and Bono_Consulta_Fecha_Impresion is not null and Bono_Consulta_Numero is not null and Turno_Numero is not null  order by Turno_Numero 
go


/*CREAR TABLA CANCELACION TURNOS*/
CREATE TABLE NOT_NULL.cancelacion_turno(
	cancelacion_id int NOT NULL,
	afiliado_nro numeric(18, 0) NULL,
	profesional_matricula int NULL,
	cancelacion_tipo char NOT NULL, --P si es de motivos personales, E si es enfermedad, L si es por motivos laborales
	cancelacion_motivo text NULL,
	cancelacion_fecha date NULL,
 CONSTRAINT [PK_cancelacion_turno] PRIMARY KEY CLUSTERED 
(
	[cancelacion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE NOT_NULL.cancelacion_turno  WITH CHECK ADD  CONSTRAINT [FK_cancelacion_turno_afiliado] FOREIGN KEY([afiliado_nro])
REFERENCES [NOT_NULL].[afiliado] ([afiliado_nro])
GO

ALTER TABLE NOT_NULL.cancelacion_turno CHECK CONSTRAINT [FK_cancelacion_turno_afiliado]
GO

ALTER TABLE NOT_NULL.cancelacion_turno  WITH CHECK ADD  CONSTRAINT [FK_cancelacion_turno_profesional] FOREIGN KEY([profesional_matricula])
REFERENCES [NOT_NULL].[profesional] ([profesional_matricula])
GO

ALTER TABLE NOT_NULL.cancelacion_turno CHECK CONSTRAINT [FK_cancelacion_turno_profesional]
GO

/*		AGENDA		*/
CREATE TABLE NOT_NULL.agenda(
	agenda_id int IDENTITY(0,1) primary key,
	id_profesional string, 
	id_especialidad string,
	--agenda_medxesp int NOT NULL foreign key references NOT_NULL.medicoXespecialidad(medxesp_id),
	agenda_fecha_inicio date,
	agenda_fecha_fin date,
	--primary key (agenda_id)
)
GO

/*TABLA FRANJA HORARIA*/
CREATE TABLE NOT_NULL.franja_horaria(
	franja_id int PRIMARY KEY IDENTITY(0,1),
	dia int NOT NULL CHECK(dia >=1 AND dia <=7),
	hora_inicio int NOT NULL CHECK(hora_inicio<24 AND hora_inicio>=0),
	minuto_inicio int NOT NULL CHECK(minuto_inicio<60 AND minuto_inicio>=0),
	hora_fin int NOT NULL CHECK(hora_fin<24 AND hora_fin>=0),
	minuto_fin int NOT NULL CHECK(minuto_fin<60 AND minuto_fin>=0),
	franja_cancelada bit default 0	,
	agenda_id int foreign key references NOT_NULL.agenda(agenda_id))
GO


ALTER TABLE NOT_NULL.franja_horaria
	ADD CONSTRAINT hora_fin_mayor_hora_inicio CHECK( (hora_fin * 60 + minuto_fin) > (hora_inicio * 60 + minuto_inicio) )
GO


/*		BONOS		*/

create table NOT_NULL.bono_consulta (
	 bono_id numeric(18,0) primary key, 
	 bono_afiliado numeric(18,0) foreign key references NOT_NULL.afiliado(afiliado_nro),
	 bono_plan numeric(18,0) foreign key references NOT_NULL.plan_medico(plan_id),
	 bono_turno numeric(18,0) foreign key references  NOT_NULL.turno(turno_nro),
	 bono_fecha_compra datetime,
	 bono_utilizado character(1),
	 bono_nro_bono_afiliado numeric(18,0)
)
go

create procedure NOT_NULL.asignar_nro_bonos_afiliado
as
Begin
	set nocount on
	declare @bono numeric(18,0)
	declare @afiliado numeric(18,0)
	declare @afiliado_estatico numeric(18,0)
	set @afiliado_estatico = 0
	declare @cantidadAcum numeric(18,0)
	set @cantidadAcum = 0
	declare unCursor cursor for select bono_id, bono_afiliado from NOT_NULL.bono_consulta order by bono_afiliado, bono_id
	open unCursor
	fetch next from unCursor into @bono, @afiliado
	while @@FETCH_STATUS = 0
	Begin
		if(@afiliado_estatico <> @afiliado)
		Begin
			set @afiliado_estatico = @afiliado
			set @cantidadAcum = 0
		End
		set @cantidadAcum = @cantidadAcum + 1
		update NOT_NULL.bono_consulta set bono_nro_bono_afiliado = @cantidadAcum where bono_id = @bono
		fetch next from unCursor into @bono, @afiliado
	End
	close unCursor
	deallocate unCursor
End
go

insert into NOT_NULL.bono_consulta (bono_id, bono_afiliado, bono_plan, bono_fecha_compra, bono_utilizado )
select Bono_Consulta_Numero, afiliado_nro, Plan_Med_Codigo, Compra_Bono_Fecha, 'S'
	from gd_esquema.Maestra, NOT_NULL.afiliado
	where Bono_Consulta_Numero is not null and Compra_Bono_Fecha is not null and afiliado_dni = Paciente_Dni
	order by Bono_Consulta_Numero, Paciente_Dni, Plan_Med_Codigo, Compra_Bono_Fecha
go

update NOT_NULL.bono_consulta set bono_turno = Turno_Numero from gd_esquema.Maestra where bono_id = Bono_Consulta_Numero and Compra_Bono_Fecha is null
go

exec NOT_NULL.asignar_nro_bonos_afiliado																				/*		Comentar para que no tarde		*/
go


/*		COMPRA BONO		*/
create table NOT_NULL.compra_bono(
	compra_id numeric(18,0) identity(1,1) primary key,
	compra_cantidad int,
	compra_precio int,
	compra_afiliado numeric(18,0) foreign key references NOT_NULL.afiliado(afiliado_nro),
	compra_fecha datetime
)
go

insert into NOT_NULL.compra_bono (compra_cantidad, compra_afiliado, compra_fecha)
	select count(Compra_Bono_Fecha), afiliado_nro, Compra_Bono_Fecha
	from gd_esquema.Maestra, NOT_NULL.afiliado
	where afiliado_dni = Paciente_Dni and
		Compra_Bono_Fecha is not null and
		Turno_Numero is null and Compra_Bono_Fecha = Bono_Consulta_Fecha_Impresion
	group by Compra_Bono_Fecha, afiliado_nro

/*AGREGO USUARIOS, ROLES y FUNCIONES*/
INSERT INTO NOT_NULL.Funcion(funcion_descripcion)
  VALUES ('ABM Rol'), ('ABM Usuario'),('ABM Afiliado'),('ABM Plan'),('ABM Profesional'),('ABM Especialidades'),
    ('Registrar Agenda'),('Comprar Bonos'), ('Pedir Turno'),('Registrar llegada'),('Registrar resultado'),('Listado Estadistico'), ('Cancelar atencion')
GO
  
  -- Roles administrador
  INSERT INTO NOT_NULL.funcionXrol(rol_id, funcion_id)
  VALUES (1, 1),(1, 2),(1, 3),(1, 4),(1, 5),(1, 6),(1,8) , (1,10), (1,12)
  GO
  -- Roles afiliado
  INSERT INTO NOT_NULL.funcionXrol(rol_id, funcion_id)
  VALUES (2, 8),(2, 9), (2,13)
  GO
  -- Roles profesional
  INSERT INTO NOT_NULL.funcionXrol(rol_id, funcion_id)
  VALUES (3, 7),(3, 11),(3, 12), (3,13)
  GO
  -- USUARIO ADMINISTRADOR
  INSERT INTO NOT_NULL.Usuario (usuario_id, usuario_password, usuario_descripcion, usuario_habilitado, usuario_cant_intentos)
  VALUES ('admin', HASHBYTES('SHA2_256', 'w23e'), 'admin', 1, 0)
  GO

  --USUARIO PROFESIONAL
  INSERT INTO NOT_NULL.Usuario(usuario_id, usuario_password, usuario_descripcion, usuario_habilitado, usuario_cant_intentos)
  VALUES ('prof', HASHBYTES('SHA2_256', 'user'), 'profesional1', 1, 0)
  GO

  --USUARIO AFILIADO
  INSERT INTO NOT_NULL.Usuario (usuario_id, usuario_password, usuario_descripcion, usuario_habilitado, usuario_cant_intentos)
  VALUES ('afil', HASHBYTES('SHA2_256', 'user'), 'afiliado1', 1, 0)
  GO

  -- ROLES ADMINISTRADOR, le pongo todos para poder probar todo
  INSERT INTO NOT_NULL.rolXusuario(usuario_id, rol_id)
  VALUES ('admin', 1), ('admin', 2), ('admin',3)
  GO

  -- ROLES PROFESIONAL
  INSERT INTO NOT_NULL.rolXusuario(usuario_id, rol_id)
  VALUES ('prof', 3)
  GO

  -- ROLES AFILIADO
  INSERT INTO NOT_NULL.rolXusuario(usuario_id, rol_id)
  VALUES ('afil', 2)
  GO

  --CREO UN USUARIO AFILIADO PARA EL ADMIN
  INSERT INTO NOT_NULL.afiliado(afiliado_nombre, afiliado_apellido, afiliado_dni, afiliado_mail, afiliado_telefono, afiliado_direccion, afiliado_cant_hijos, afiliado_fecha_nac, afiliado_estado_civil, afiliado_plan, afiliado_sexo, usuario_id)
  VALUES ('admin', 'istrador', 32405354, 'admin@gdd.com', '+5491168489235', 'Avenida Leandro N. Alem 5458 piso 18 depto Q 1558', 0, CONVERT(DATETIME,1995-07-12), 'S',NULL, 'M', 'admin')
  GO
  --CREO UN USUARIO PROFESIONAL PARA EL ADMIN
  INSERT INTO NOT_NULL.profesional(profesional_nombre, profesional_apellido, profesional_dni, profesional_tipo_doc, profesional_telefono, profesional_direccion, profesional_fecha_nacimiento, profesional_sexo, profesional_mail,  usuario_id)
  VALUES ('admin', 'istrador', 32405353, 'D',  '+5491168489235', 'Avenida Leandro N. Alem 5458 piso 18 depto Q 1558', CONVERT(DATETIME,1995-07-12), 'M','admin@gdd.com', 'admin')
  GO
  --LOGIN PARA LOS USUARIOS
  CREATE PROCEDURE NOT_NULL.Usuario_LogIn (@username varchar(50), @password varchar(20))
  AS
  BEGIN
   SET NOCOUNT ON;
   SELECT * FROM NOT_NULL.Usuario WHERE usuario_id = @username AND usuario_password =  HASHBYTES('SHA2_256', @password) and usuario_habilitado = 1
   UPDATE NOT_NULL.usuario SET usuario_cant_intentos = 0 WHERE usuario_id = @username and usuario_password = HASHBYTES('SHA2_256', @password) and usuario_habilitado = 1 
  END
  GO
  
  --OBTENER TODOS LOS USUARIOS
  CREATE PROCEDURE NOT_NULL.Usuario_GetAll 
  AS
	BEGIN
		SET NOCOUNT ON;
		SELECT * FROM NOT_NULL.Usuario
	END
  GO

  --OBTENER TODOS LOS ROLES DE UN USUARIO
  CREATE PROCEDURE NOT_NULL.UsuarioXRol_GetRolesByUser (@username varchar(50))
  AS
	BEGIN
		SET NOCOUNT ON;
		SELECT * FROM NOT_NULL.Rol WHERE rol_id in (SELECT rol_id FROM NOT_NULL.rolXusuario WHERE usuario_id = @username and rolXusuario_habilitado = 1)
	END
  GO

  --OBTENER TODOS LOS ROLES INHABILITADOS DE UN USUARIO
  CREATE PROCEDURE NOT_NULL.UsuarioXRol_GetRolesInhabxUser (@username varchar(50))
  AS
	BEGIN
		SET NOCOUNT ON;
		SELECT * FROM NOT_NULL.Rol WHERE rol_id in (SELECT rol_id FROM NOT_NULL.rolXusuario WHERE usuario_id = @username and rolXusuario_habilitado = 0)
	END
  GO

  --OBTENER TODAS LAS FUNCIONES DE UN ROL
  CREATE PROCEDURE NOT_NULL.RolXFuncion_GetFunByRol (@rol int)
  AS
	BEGIN
		SET NOCOUNT ON;
		SELECT * FROM NOT_NULL.Funcion WHERE funcion_id in (SELECT funcion_id FROM NOT_NULL.funcionXrol WHERE rol_id = @rol and funcionXrol_activo = 1)
	END
  GO


  --ME FIJO SI UN ROL EXISTE
  CREATE PROCEDURE NOT_NULL.Rol_Exists (@rol char(18))
  AS
	BEGIN
		SET NOCOUNT ON;
		SELECT * FROM NOT_NULL.Rol WHERE rol_descripcion = @rol
	END
  GO

  
  --ME FIJO SI UN USUARIO EXISTE
  CREATE PROCEDURE NOT_NULL.Usuario_Exists (@usuarioid varchar(50))
  AS
	BEGIN
		SET NOCOUNT ON;
		SELECT * FROM NOT_NULL.Usuario WHERE usuario_id = @usuarioid
	END
  GO

  --ME FIJO SI YA HAY ALGUIEN CON ESE DNI
  create procedure NOT_NULL.Afiliado_MismoDni(@dni varchar(8))
  as
	begin
		SET NOCOUNT ON;
		select * from NOT_NULL.afiliado where afiliado_dni = @dni
	end
  go


  --OBTENER TODAS LAS FUNCIONES 
  CREATE PROCEDURE NOT_NULL.Funciones_GetAll
  AS
	BEGIN
		SET NOCOUNT ON;
		SELECT * FROM NOT_NULL.Funcion
	END
  GO
  
  --AGREGO UNA FUNCION A UN ROL
  CREATE PROCEDURE NOT_NULL.RolXFuncion_Add(@rol int, @funcion int)
  AS
	BEGIN
		SET NOCOUNT ON;
		IF NOT EXISTS (SELECT * FROM NOT_NULL.funcionXrol WHERE funcion_id = @funcion AND rol_id = @rol) 
			INSERT INTO NOT_NULL.funcionXrol(rol_id, funcion_id)
			VALUES (@rol, @funcion)
		ELSE
			UPDATE NOT_NULL.funcionXrol
			SET funcionXrol_activo=1 WHERE funcion_id = @funcion AND rol_id = @rol  
	END
  GO

  --OBTENGO TODOS LOS ROLES DE UNA FUNCION QUE ESTAN ACTIVOS
  CREATE PROCEDURE NOT_NULL.RolXFuncion_Active(@rol varchar(50))
  AS
	BEGIN
		SET NOCOUNT ON;
		SELECT funcion.funcion_id, funcion_descripcion
		FROM NOT_NULL.funcion, NOT_NULL.funcionXrol, NOT_NULL.rol where NOT_NULL.funcionXrol.funcionXrol_activo = 1 and NOT_NULL.rol.rol_descripcion = @rol and NOT_NULL.funcionXrol.rol_id = NOT_NULL.rol.rol_id  and NOT_NULL.funcion.funcion_id = NOT_NULL.funcionXrol.funcion_id
		group by funcion.funcion_id, funcion_descripcion
	END
  GO
  --SACARLE UNA FUNCION A UN ROL
  CREATE PROCEDURE NOT_NULL.RolXFuncion_Remove(@rol int, @funcion int)
  AS
	BEGIN
		SET NOCOUNT ON; 
		UPDATE NOT_NULL.funcionXrol
		SET funcionXrol_activo=0 WHERE funcion_id = @funcion AND rol_id = @rol  
	END
  GO


  --AGREGAR ROL
  CREATE PROCEDURE NOT_NULL.Rol_Add(@rol char(18))
  AS
	BEGIN
		SET NOCOUNT ON;
		INSERT INTO NOT_NULL.Rol(rol_descripcion)
		VALUES (@rol)
	END
  GO

  --MODIFICAR NOMBRE DE ROL
  CREATE PROCEDURE NOT_NULL.Rol_ModifyName(@nombre char(18), @id int)
  AS
	BEGIN
	SET NOCOUNT ON;
	UPDATE NOT_NULL.Rol
	SET rol_descripcion = @nombre WHERE rol_id = @id
  END
  GO
  
  --OBTENER ROL POR NOMBRE
  CREATE PROCEDURE NOT_NULL.Rol_GetByName(@nombre char(18))
  AS
	BEGIN
	SET NOCOUNT ON;
		 SELECT * FROM NOT_NULL.Rol WHERE rol_descripcion = @nombre
  END
  GO

  --OBTENER TODOS LOS ROLES
  CREATE PROCEDURE NOT_NULL.Rol_GetAll
  AS
	BEGIN
		SET NOCOUNT ON;
		SELECT * FROM NOT_NULL.Rol 
	END
  GO

  --CREAR USUARIO
  CREATE PROCEDURE NOT_NULL.Usuario_Add(@Username varchar(50), @Password varchar(20), @Descripcion varchar(50))
  AS
	BEGIN
	SET NOCOUNT ON;
		INSERT INTO NOT_NULL.Usuario (usuario_id, usuario_password, usuario_descripcion, usuario_habilitado, usuario_cant_intentos)
		VALUES (@Username, HASHBYTES('SHA2_256', @Password), @Descripcion, 1, 0)
	END
  GO

  --CREAR PROFESIONAL
  CREATE PROCEDURE NOT_NULL.Profesional_Add(@Username varchar(50), @Nombre varchar(50),@Apellido varchar(50),@Dni numeric(8,0), @TipoDoc char(1), @Mail varchar(50), @Telefono varchar(20), @Direccion varchar(50), @Sexo char(1), @FechaNacimiento datetime)
  AS
	BEGIN
	SET NOCOUNT ON;
		INSERT INTO NOT_NULL.profesional(usuario_id, profesional_nombre, profesional_apellido,profesional_dni, profesional_tipo_doc, profesional_mail, profesional_telefono, profesional_direccion, profesional_sexo,profesional_fecha_nacimiento)
		VALUES (@Username,@Nombre, @Apellido, @Dni, @TipoDoc, @Mail, @Telefono, @Direccion, @Sexo, @FechaNacimiento )
		--INSERT INTO NOT_NULL.rolXusuario(usuario_id, rol_id)
		--VALUES (@Username, 3)
	END
  GO

  --OBTENER EL ULTIMO NUMERO DE AFILIADO
  create procedure NOT_NULL.Afiliado_Obtener_Nro
  as
	begin 
	set nocount on;
		select top 1 * from afiliado 
		order by afiliado_nro desc
	end
  go

  --CREAR AFILIADO
  CREATE PROCEDURE NOT_NULL.Afiliado_Add(@Username varchar(50), @Nombre varchar(50),@Apellido varchar(50), @Dni numeric(8,0), @Mail varchar(50),@Telefono varchar(20), @Direccion varchar(50), @CantHijos numeric(2,0), @EstadoCivil char(1), @Fecha datetime, @Plan numeric(18,0), @Sexo char(1))
  AS
	BEGIN
	SET NOCOUNT ON;
		INSERT INTO NOT_NULL.afiliado(usuario_id,afiliado_nombre,afiliado_apellido,afiliado_dni,afiliado_mail,afiliado_telefono,afiliado_direccion,afiliado_cant_hijos,afiliado_estado_civil, afiliado_fecha_nac, afiliado_plan, afiliado_sexo)
		VALUES (@Username, @Nombre, @Apellido, @Dni, @Mail, @Telefono,@Direccion, 0, @EstadoCivil, @Fecha, @Plan, @Sexo)
		--INSERT INTO NOT_NULL.rolXusuario(usuario_id, rol_id)
		--VALUES (@Username, 2)
	END
  GO

  --MODIFICAR PROFESIONAL
  CREATE PROCEDURE NOT_NULL.Profesional_Modify(@Username varchar(50), @Nombre varchar(50),@Apellido varchar(50),@Dni numeric(8,0), @TipoDoc char(1), @Mail varchar(50), @Telefono varchar(20), @Direccion varchar(50), @Sexo char(1), @FechaNacimiento datetime)
  AS
	BEGIN
	SET NOCOUNT ON; 
		UPDATE NOT_NULL.profesional
		SET usuario_id = @Username, profesional_nombre = @Nombre, profesional_apellido = @Apellido,profesional_dni = @Dni, profesional_tipo_doc = @TipoDoc, profesional_mail = @Mail, profesional_telefono = @Telefono, profesional_direccion = @Direccion, profesional_sexo = @Sexo,profesional_fecha_nacimiento = @FechaNacimiento
		WHERE usuario_id = @Username
	END
  GO


  --MODIFICAR AFILIADO
  CREATE PROCEDURE NOT_NULL.Afiliado_Modify(@Username varchar(50), @Nombre varchar(50),@Apellido varchar(50), @Dni numeric(8,0), @Mail varchar(50),@Telefono varchar(20), @Direccion varchar(50), @CantHijos numeric(2,0), @EstadoCivil char(1), @Fecha datetime,@Plan numeric(18,0), @Sexo char(1))
  AS
	BEGIN
	SET NOCOUNT ON;
		UPDATE NOT_NULL.afiliado
		SET usuario_id = @Username,afiliado_nombre=@Nombre,afiliado_apellido=@Apellido,afiliado_dni=@Dni,afiliado_mail=@Mail,afiliado_telefono=@Telefono,afiliado_direccion=@Direccion,afiliado_cant_hijos = (select afiliado_cant_hijos from afiliado where usuario_id = @Username), afiliado_estado_civil=@EstadoCivil, afiliado_fecha_nac=@Fecha,  afiliado_plan=@Plan, afiliado_sexo=@Sexo
		WHERE usuario_id = @Username
	END
  GO


  --OBTENER PLAN AFILIADO
  CREATE PROCEDURE NOT_NULL.Planes_GetPlanAfiliado(@Afiliado_nro int)
  as
	begin
	set nocount on;
		select plan_cuota_precio, plan_descripcion, plan_id, plan_precio_bono_consulta from NOT_NULL.plan_medico, afiliado where afiliado_nro = @Afiliado_nro and afiliado_plan = plan_id 
	end
  go


  --OBTENER PLAN POR ID
  create procedure NOT_NULL.Planes_GetPorId(@IdPlan int)
  as
	begin
	set nocount on;
		select * from plan_medico where plan_id = @IdPlan
	end
  go

  --OBTENER TODOS LOS PLANES MENOS EL DEL AFILIADO ACTUAL
  CREATE PROCEDURE NOT_NULL.Planes_GetAll
  AS
	BEGIN
	SET NOCOUNT ON;
		SELECT * FROM NOT_NULL.plan_medico ORDER BY plan_id
	END
  GO

  --CAMBIAR CONTRASEÑA DE USUARIO
  CREATE PROCEDURE NOT_NULL.Usuario_CambiarContrasenia(@Username varchar(50), @Password varchar(20), @cambiada int output)
  AS
	BEGIN
	SET NOCOUNT ON;
		declare @vieja varchar(20);
		set @vieja = (select usuario.usuario_password from usuario where usuario_id = @Username)
		UPDATE NOT_NULL.Usuario
		SET usuario_password = HASHBYTES('SHA2_256', @Password)
		WHERE usuario_id = @Username 
		set @cambiada = 1;
	END
  GO

  

  --ACTUALIZAR PLAN AFILIADO
  CREATE PROCEDURE NOT_NULL.Agregar_Modif_Plan(@PlanNuevoId int, @Username varchar(50), @Motivo varchar(255))
  as
	begin 
	set nocount on;
	insert into modificacion_plan (modif_afiliado, modif_plan_viejo, modif_motivo, modif_plan_fecha, modif_plan_nuevo)
	values((select afiliado_nro from afiliado where usuario_id = @Username),
	(select afiliado_plan from afiliado where usuario_id = @Username), @Motivo, GETDATE(), @PlanNuevoId)
	end
  go

  --OBTENER TODAS LAS MODIFICACIONES DE PLAN
  create procedure NOT_NULL.Modif_Plan_Get_All
  as
	begin
	set nocount on;
		select afiliado.afiliado_nombre, afiliado.afiliado_apellido, modif_motivo, modif_plan_fecha, p1.plan_descripcion, p2.plan_descripcion
		 from NOT_NULL.modificacion_plan, NOT_NULL.afiliado, NOT_NULL.plan_medico p1, NOT_NULL.plan_medico p2
		 where modif_afiliado = afiliado_nro and modif_plan_nuevo = p1.plan_id and modif_plan_viejo = p2.plan_id
	end
  go


  --ACTIVAR USUARIO
  CREATE PROCEDURE NOT_NULL.Usuario_Activo(@Username varchar(50), @Activo bit)
  AS
	BEGIN
	SET NOCOUNT ON;
		UPDATE NOT_NULL.Usuario
		SET usuario_habilitado = @Activo
		WHERE usuario_id = @Username
	END
  GO

  --drop procedure NOT_NULL.Afiliado_GetAll
  --OBTENER TODOS LOS AFILIADOS
  CREATE PROCEDURE NOT_NULL.Afiliado_GetAll
  AS
	BEGIN
	SET NOCOUNT ON;
		SELECT * FROM NOT_NULL.afiliado ORDER BY afiliado_nombre, afiliado_apellido, afiliado_dni
	END
  GO


  --OBTENER TODOS LOS PROFESIONALES
  CREATE PROCEDURE NOT_NULL.Profesionales_GetAll
  AS
	BEGIN
	SET NOCOUNT ON;
		SELECT * FROM NOT_NULL.profesional
	END
  GO


  --OBTENER AFILIADOS CON FILTROS
  CREATE PROCEDURE NOT_NULL.Afiliado_GetByFilters(@nombre varchar(50), @apellido varchar(50), @mail varchar(50))
  AS
	BEGIN
	SET NOCOUNT ON;
		SELECT * FROM NOT_NULL.afiliado 
		WHERE afiliado_nombre LIKE ('%' + @nombre + '%') 
		AND afiliado_apellido LIKE ('%' + @apellido+ '%') 
		AND afiliado_mail LIKE ('%' + @mail + '%')  
	END
  GO


  --OBTENER PROFESIONALES CON FILTROS
  CREATE PROCEDURE NOT_NULL.Profesional_GetByFilters(@nombre varchar(255), @mail varchar(50))
  AS
	BEGIN
	SET NOCOUNT ON;
		SELECT * FROM NOT_NULL.profesional 
		WHERE profesional_nombre LIKE ('%' + @nombre + '%')
		AND profesional_mail LIKE ('%' + @mail + '%') 
	END
  GO


  --OBTENER AFILIADOS POR DNI
  CREATE PROCEDURE NOT_NULL.Afiliado_GetByDni(@dni numeric(8,0))
  AS
	BEGIN
	SET NOCOUNT ON;
		SELECT * FROM NOT_NULL.afiliado 
		WHERE afiliado_dni = @dni   
	END
  GO


  --OBTENER PROFESIONALES POR DNI
  CREATE PROCEDURE NOT_NULL.Profesional_GetByDni(@dni numeric(8,0))
  AS
	BEGIN
	SET NOCOUNT ON;
		SELECT * FROM NOT_NULL.profesional 
		WHERE profesional_dni = @dni
	END
  GO

  --OBTENER ESPECIALIDAD POR MATRICULA Profesional
  CREATE PROCEDURE NOT_NULL.Especialidad_GetByMatricula(@matricula int)
  AS BEGIN
	SET NOCOUNT ON;
		SELECT e.especialidad_codigo, e.especialidad_descripcion, et.tipo_especialidad_descripcion
		FROM NOT_NULL.especialidad e, NOT_NULL.especialidad_tipo et, NOT_NULL.medicoXespecialidad mxe
		WHERE mxe.medxesp_profesional = @matricula AND e.especialidad_codigo = mxe.medxesp_especialidad
			AND et.tipo_especialidad_codigo = e.especialidad_tipo
	END
  GO
  
  --OBTENER AFILIADO SEGUN USUARIO
  CREATE PROCEDURE NOT_NULL.Afiliado_GetAfiliadoSegunUsuario (@username varchar(50))
  AS
	BEGIN
		select * from NOT_NULL.afiliado where usuario_id = @username
	END
  GO


  --OBTENER BONOS POR AFILIADO
  CREATE PROCEDURE NOT_NULL.Bonos_GetBonosSegunAfiliado (@ID numeric(18,0))
  AS
	BEGIN
		select * from NOT_NULL.bono_consulta where bono_afiliado = @ID order by bono_fecha_compra desc
	END
  GO


  --OBTENER PROFESIONAL POR USUARIO
  CREATE PROCEDURE NOT_NULL.Profesional_GetProfesionalSegunUsuario (@username varchar(50))
  AS
	BEGIN
		SELECT * FROM NOT_NULL.profesional WHERE usuario_id = @username
	END
  GO


  --HABILITAR USUARIO POR NOMBRE
  CREATE PROCEDURE NOT_NULL.Usuario_Habilitar(@Username varchar(50))
  AS
	BEGIN
		UPDATE NOT_NULL.Usuario
		SET usuario_habilitado = 1, usuario_cant_intentos = 0
		WHERE usuario_id = @Username
	END
  GO


  --INHABILITAR USUARIO POR NOMBRE
  CREATE PROCEDURE NOT_NULL.Usuario_Inhabilitar(@Username varchar(50))
  AS
	BEGIN
		UPDATE NOT_NULL.Usuario
		SET usuario_habilitado = 0
		WHERE usuario_id = @Username
	END
  GO


  --ACTIVAR ROL
  CREATE PROCEDURE NOT_NULL.Rol_Activate(@rol int)
  AS
	BEGIN
	SET NOCOUNT ON;
		UPDATE NOT_NULL.Rol
		SET rol_habilitado = 1 WHERE rol_id = @rol
	END
  GO


  --VOLVER A ACTIVAR USUARIO X ROL
  CREATE PROCEDURE NOT_NULL.RolXUsuario_Activate(@rol int, @usuario varchar(50))
  AS
	BEGIN
	SET NOCOUNT ON;
		UPDATE NOT_NULL.rolXusuario
		SET rolXusuario_habilitado = 1 WHERE rol_id = @rol and rolXusuario.usuario_id = @usuario
	END
  GO

  --DESACTIVAR ROL
  CREATE PROCEDURE NOT_NULL.Rol_Deactivate(@rol int)
  AS
	BEGIN
	SET NOCOUNT ON;
		UPDATE NOT_NULL.Rol
		SET rol_habilitado = 0 WHERE rol_id = @rol
		--Agrego aca para que cuando se deshabilite un rol tambien se deshabiliten los usuarios que tienen ese rol
		UPDATE NOT_NULL.rolXusuario
		SET rolXusuario_habilitado = 0 WHERE rol_id = @rol
	END
  GO

  /*Le agrego un plan al administrador*/
  update NOT_NULL.afiliado set afiliado_plan = (select top 1 NOT_NULL.plan_medico.plan_id from NOT_NULL.plan_medico) where usuario_id = 'administrador32405354'
  go

  

  /*DAR DE BAJA LOGICA UN AFILIADO (ACORDARSE QUE CUANDO SE HACE ESTO TAMBIEN TENGO QUE PONER TODOS LOS TURNOS DEL AFILIADO COMO DISPONIBLES)*/
  create procedure NOT_NULL.Afiliado_Baja_Logica(@UsuarioId varchar(50))
  as
	begin
	set nocount on;
		update NOT_NULL.rolXusuario set rolXusuario_habilitado = 0 where usuario_id = @UsuarioId and rol_id = 2
		--set @ret = (select count(*) from NOT_NULL.rolXusuario where usuario_id = @UsuarioId and rol_id = 2 and rolXusuario_habilitado = 0) 
	end
  go

  



  /*AGREGAR UN FAMILIAR AL AFIIADO*/
  create procedure NOT_NULL.Afiliado_Agregar_Familiar (@Afiliado_nro_familiar int, @Username varchar(50), @Nombre varchar(50),@Apellido varchar(50), @Dni numeric(8,0), @Mail varchar(50),@Telefono varchar(20), @Direccion varchar(50), @CantHijos numeric(2,0), @EstadoCivil char(1), @Fecha datetime, @Plan numeric(18,0), @Sexo char(1))
  as
	begin;
		DISABLE TRIGGER NOT_NULL.crear_usuario ON NOT_NULL.afiliado
		SET IDENTITY_INSERT NOT_NULL.afiliado ON
			declare @nroafil int;
			set @nroafil = (select top 1 afiliado.afiliado_nro from afiliado where ROUND(afiliado.afiliado_nro/100, 0) = ROUND(@Afiliado_nro_familiar/100, 0) order by afiliado_nro desc) + 1
			--set @nroafil = @Afiliado_nro_familiar + 1
			insert into NOT_NULL.usuario (usuario_id, usuario_cant_intentos, usuario_descripcion, usuario_password, usuario_habilitado)
			values (@Nombre + @Apellido + CAST(@Dni as varchar(8)), 0, 'Afiliado',HASHBYTES('SHA2_256', 'afiliado'), 1)
			insert into NOT_NULL.afiliado (afiliado_nro, usuario_id, afiliado_nombre, afiliado_apellido, afiliado_dni, afiliado_cant_hijos, afiliado_direccion, afiliado_estado_civil, afiliado_fecha_nac, afiliado_mail, afiliado_plan, afiliado_sexo, afiliado_telefono)
		     values(@nroafil, @Nombre + @Apellido + CAST(@Dni as varchar(8)), @Nombre, @Apellido, @Dni, @CantHijos, @Direccion, @EstadoCivil, @Fecha, @Mail, @Plan, @Sexo, @Telefono) 
			insert into NOT_NULL.rolXusuario (rolXusuario_habilitado, rol_id, usuario_id) 
			values (1, 2, @Nombre + @Apellido + CAST(@Dni as varchar(8)))
			SET IDENTITY_INSERT NOT_NULL.afiliado OFF;
		ENABLE TRIGGER NOT_NULL.crear_usuario ON NOT_NULL.afiliado
	end 
  go


  --AGREGAR AGENDA
  CREATE PROCEDURE NOT_NULL.Agenda_Agregar(@matricula int, @especialidad varchar(255), @fecha_inicio datetime, @fecha_fin datetime, @id_agenda int OUTPUT)
  AS BEGIN
  
	INSERT INTO NOT_NULL.Agenda a
	VALUES(@fecha_inicio, @fecha_fin)
	
	UPDATE NOT_NULL.medicoXespecialidad mxe
	SET mxe.medxesp_agenda = @@IDENTITY
	WHERE mxe.medxesp_profesional = @matricula 
		AND mxe.medxesp_especialidad = (SELECT e.especialidad_codigo TOP 1
										FROM NOT_NULL.especialidad e
										WHERE e.especialidad_descripcion = @especialidad)
	
	@id_agenda = @@IDENTITY
	END
  GO
  
  --AGREGAR FRANJA
  CREATE PROCEDURE NOT_NULL.Franja_Agregar(@id_agenda int, @hora_inicio int, @minuto_inicio int, @hora_fin int, @minuto_fin int)
  AS BEGIN
	
	INSERT INTO NOT_NULL.Agenda
	values(@id_agenda,@hora_inicio,@minuto_inicio,@hora_fin,@minuto_fin)
	
	END
  GO
  
  
  update NOT_NULL.plan_medico set plan_cuota_precio = 500 where plan_id = 555555
  update NOT_NULL.plan_medico set plan_cuota_precio = 1000 where plan_id = 555556
  update NOT_NULL.plan_medico set plan_cuota_precio = 2000 where plan_id = 555557
  update NOT_NULL.plan_medico set plan_cuota_precio = 5000 where plan_id = 555558
  update NOT_NULL.plan_medico set plan_cuota_precio = 10000 where plan_id = 555559
  go

  create procedure NOT_NULL.Get_MedicoXEsp_All
  as
	begin
		select medicoXespecialidad.medxesp_id,profesional_nombre,profesional_apellido, profesional_direccion, especialidad_descripcion 
		from NOT_NULL.medicoXespecialidad, NOT_NULL.profesional, NOT_NULL.especialidad 
		where NOT_NULL.medicoXespecialidad.medxesp_especialidad = especialidad_codigo and medicoXespecialidad.medxesp_profesional = profesional_matricula
	end
  go

  create procedure NOT_NULL.Get_Especialidades_All
  as
	begin
		select especialidad.especialidad_descripcion from especialidad
	end
  go

  create procedure NOT_NULL.Get_Turnos_Today
  as
	begin
		select * from NOT_NULL.turno where turno_fecha = CONVERT(DATE, GETDATE());
	end
  go
  
  -- FILTRADO DE DIAS DE TURNOS SEGUN CODIGO_PROFESIONAL
  CREATE PROCEDURE NOT_NULL.turnos_GetByFilerProfesional (@profesional varchar(20), @especialidad varchar(20))
  AS
	BEGIN
	SET NOCOUNT ON;
	SELECT STR(franja_id) as id,
		   STR(dia) as dia,
		   STR(hora_inicio) as hora_inicio,
		   STR(minuto_inicio) as minuto_inicio, 
		   STR(hora_fin) as hora_fin,
		   STR(minuto_fin) as minuto_fin
		   FROM NOT_NULL.franja_horaria WHERE agenda_id IN 
				(
				  	 SELECT agenda_id 
					 FROM NOT_NULL.agenda 
					 WHERE id_profesional = @profesional 
					 and id_especialidad = @especialidad
					 and agenda_fecha_inicio >= '09/10/2016'
				 )
	END
  GO  
  
  --FILTRADO DE PROFESIONALES POR ESPECIALIDAD
  CREATE PROCEDURE NOT_NULL.profesional_GetByFilerEspecialidad (@especialidad varchar(20))
  AS
	BEGIN
	SET NOCOUNT ON;
	SELECT profesional_matricula,
		   profesional_nombre,
	       profesional_apellido,
	       profesional_mail,
	       STR(profesional_telefono) as profesional_telefono,
	       profesional_direccion
	       FROM NOT_NULL.profesional 
	WHERE profesional_matricula IN 
									(
									 SELECT medxesp_profesional, medxesp_agenda 
									 FROM NOT_NULL.medicoXespecialidad 
									 WHERE medxesp_especialidad = str(@especialidad)
									 )	
	END
  GO  
  
  
  /*
  alter table not_null.agenda add id_profesional varchar(20)
  alter table not_null.agenda add id_especialidad varchar(20)
  select * from NOT_NULL.agenda
  
  insert into 
  update 
  
  select * from NOT_NULL.medicoXespecialidad
  
  select * from NOT_NULL.usuario where usuario_id = 'admin'
  update NOT_NULL.usuario set usuario_password = HASHBYTES('SHA2_256', 'admin') where usuario_id = 'admin'
  */