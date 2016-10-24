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

set nocount on;
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

set nocount on;
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
	set nocount on;
	insert into NOT_NULL.usuario (usuario_id, usuario_cant_intentos, usuario_descripcion, usuario_password, usuario_habilitado)
	select profesional_nombre + profesional_apellido + CAST(profesional_dni as varchar(8)), 0, 'Profesional',HASHBYTES('SHA2_256', 'profesional'), 1 from inserted where inserted.profesional_nombre is not null and inserted.profesional_apellido is not null and inserted.profesional_dni is not null
	insert into NOT_NULL.rolXusuario (usuario_id, rolXusuario_habilitado, rol_id)
	(select profesional_nombre + profesional_apellido + CAST(profesional_dni as varchar(8)), 1, 3 from inserted where profesional_nombre is not null and profesional_apellido is not null and profesional_dni is not null)
End
go


set nocount on;
insert into NOT_NULL.profesional
(profesional_nombre, profesional_apellido, profesional_dni, profesional_direccion, profesional_telefono, profesional_mail, profesional_fecha_nacimiento, profesional_sexo, profesional_tipo_doc)
select Medico_Nombre, Medico_Apellido, Medico_Dni, Medico_Direccion, Medico_Telefono, Medico_Mail, Medico_Fecha_Nac, 'N', 'D' 
	from gd_esquema.Maestra
	where Medico_Nombre <> 'NULL'
	group by Medico_Nombre, Medico_Apellido, Medico_Dni, Medico_Direccion, Medico_Telefono, Medico_Mail, Medico_Fecha_Nac 
go

set nocount on;
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

set nocount on;
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

set nocount on;
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
	 afiliado_tipo_dni char(1) default 'D',				--D: dni, L: libreta civica, C: cedula identidad, E: libreta enrolamiento
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
		set nocount on;
			insert into NOT_NULL.usuario (usuario_id, usuario_cant_intentos, usuario_descripcion, usuario_password, usuario_habilitado)
			select afiliado_nombre + afiliado_apellido + CAST(afiliado_dni as varchar(8)), 0, 'Afiliado',HASHBYTES('SHA2_256', 'afiliado'), 1 from inserted where inserted.afiliado_nombre is not null and inserted.afiliado_apellido is not null and inserted.afiliado_dni is not null;
			insert into NOT_NULL.afiliado (usuario_id, afiliado_nombre, afiliado_apellido, afiliado_tipo_dni,afiliado_dni, afiliado_cant_hijos, afiliado_direccion, afiliado_estado_civil, afiliado_fecha_nac, afiliado_mail, afiliado_plan, afiliado_sexo, afiliado_telefono)
			(select afiliado_nombre + afiliado_apellido + CAST(afiliado_dni as varchar(8)), afiliado_nombre, afiliado_apellido,afiliado_tipo_dni, afiliado_dni, 0, afiliado_direccion, afiliado_estado_civil, afiliado_fecha_nac, afiliado_mail, afiliado_plan, afiliado_sexo, afiliado_telefono from inserted  
			where inserted.afiliado_nombre is not null and inserted.afiliado_apellido is not null and inserted.afiliado_dni is not null);
			insert into NOT_NULL.rolXusuario (rolXusuario_habilitado, rol_id, usuario_id) 
			(select 1, 2, afiliado_nombre + afiliado_apellido + CAST(afiliado_dni as varchar(8)) from inserted
			where inserted.afiliado_nombre is not null and inserted.afiliado_apellido is not null and inserted.afiliado_dni is not null)
		end
		else
		begin
		set nocount on;
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

set nocount on;
insert into NOT_NULL.afiliado
(afiliado_nombre, afiliado_apellido,  afiliado_tipo_dni,afiliado_dni, afiliado_estado_civil, 
afiliado_sexo, afiliado_fecha_nac, afiliado_telefono, afiliado_mail, afiliado_direccion, afiliado_cant_hijos, afiliado_plan)
select Paciente_Nombre, Paciente_Apellido,'D',Paciente_Dni, 'N', 'N', Paciente_Fecha_Nac, Paciente_Telefono, Paciente_Mail, Paciente_Direccion, 0, Plan_Med_Codigo 
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
	/*turno_nro numeric(18, 0) NOT NULL,*/
	turno_nro numeric(18,0) /*identity(1,1)*/,
	afiliado_nro numeric(18, 0) NULL,
	turno_fecha datetime NULL,
	turno_estado char(1) default 'D' NULL , --ESTADO D disponible R reservado U usado L llego
	turno_hora_llegada datetime NULL,
	--turno_sintomas varchar(255) NULL,
	--turno_enfermedades varchar(255) NULL,
	turno_medico_especialidad_id int NULL,
	turno_tiempo bit NULL,
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

set nocount on;
insert into NOT_NULL.turno(turno_nro, afiliado_nro, turno_fecha, turno_estado, turno_hora_llegada, /*turno_sintomas , turno_enfermedades,*/ turno_medico_especialidad_id, turno_tiempo)
select Turno_Numero, afiliado_nro, Turno_Fecha, 'U', Bono_Consulta_Fecha_Impresion, /*Consulta_Sintomas, Consulta_Enfermedades,*/ medxesp_id, 1
	from gd_esquema.Maestra, NOT_NULL.afiliado, NOT_NULL.medicoXespecialidad, NOT_NULL.profesional
	where afiliado_dni = Paciente_Dni and medxesp_especialidad = Especialidad_Codigo and medXesp_profesional = profesional_matricula
		and profesional_dni = Medico_Dni
		and Bono_Consulta_Fecha_Impresion is not null and Bono_Consulta_Numero is not null and Turno_Numero is not null  order by Turno_Numero 
go

set nocount on;
create table NOT_NULL.consulta(
	consulta_id int identity(1,1) NOT NULL,
	consulta_sintomas varchar(255) NULL,
	consulta_enfermedades varchar(255) NULL,
	consulta_turno numeric(18,0) NOT NULL foreign key references NOT_NULL.turno(turno_nro) 
)
go

/*CREAR TABLA CANCELACION TURNOS*/
CREATE TABLE NOT_NULL.cancelacion_turno(
	cancel_id int identity(1,1) NOT NULL,
	cancel_afiliado numeric(18, 0) NULL,
	cancel_profesional int NULL,
	cancel_tipo char NOT NULL, --M si es de motivos personales, E si es enfermedad, L si es por motivos laborales
	cancel_motivo text NULL,
	cancel_fecha date NULL,
	cancel_turno numeric(18,0) NULL,
 CONSTRAINT [PK_cancelacion_turno] PRIMARY KEY CLUSTERED 
(
	cancel_id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE NOT_NULL.cancelacion_turno  WITH CHECK ADD  CONSTRAINT [FK_cancelacion_turno_afiliado] FOREIGN KEY([cancel_afiliado])
REFERENCES [NOT_NULL].[afiliado] ([afiliado_nro])
GO

ALTER TABLE NOT_NULL.cancelacion_turno CHECK CONSTRAINT [FK_cancelacion_turno_afiliado]
GO

ALTER TABLE NOT_NULL.cancelacion_turno  WITH CHECK ADD  CONSTRAINT [FK_cancelacion_turno_profesional] FOREIGN KEY([cancel_profesional])
REFERENCES [NOT_NULL].[profesional] ([profesional_matricula])
GO

ALTER TABLE NOT_NULL.cancelacion_turno CHECK CONSTRAINT [FK_cancelacion_turno_profesional]
GO

ALTER TABLE NOT_NULL.cancelacion_turno  WITH CHECK ADD  CONSTRAINT [FK_cancelacion_turno_turno] FOREIGN KEY([cancel_turno])
REFERENCES [NOT_NULL].[turno] ([turno_nro])
GO

/*		AGENDA		*/
CREATE TABLE NOT_NULL.agenda(
	agenda_id int IDENTITY(0,1) primary key,
	--agenda_medxesp int NOT NULL foreign key references NOT_NULL.medicoXespecialidad(medxesp_id),
	agenda_fecha_inicio date,
	agenda_fecha_fin date,
	--primary key (agenda_id)
)
GO

/*TABLA FRANJA HORARIA*/
CREATE TABLE NOT_NULL.franja_horaria(
	franja_id int PRIMARY KEY IDENTITY(0,1),
	dia int NOT NULL CHECK(dia >=0 AND dia <=6),
	hora_inicio int NOT NULL CHECK(hora_inicio<24 AND hora_inicio>=0),
	minuto_inicio int NOT NULL CHECK(minuto_inicio<60 AND minuto_inicio>=0),
	hora_fin int NOT NULL CHECK(hora_fin<24 AND hora_fin>=0),
	minuto_fin int NOT NULL CHECK(minuto_fin<60 AND minuto_fin>=0),
	franja_cancelada bit default 0	,
	id_afiliado varchar(20) NULL,
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

set nocount on;
insert into NOT_NULL.bono_consulta (bono_id, bono_afiliado, bono_plan, bono_fecha_compra, bono_utilizado )
select Bono_Consulta_Numero, afiliado_nro, Plan_Med_Codigo, Compra_Bono_Fecha, 'S'
	from gd_esquema.Maestra, NOT_NULL.afiliado
	where Bono_Consulta_Numero is not null and Compra_Bono_Fecha is not null and afiliado_dni = Paciente_Dni
	order by Bono_Consulta_Numero, Paciente_Dni, Plan_Med_Codigo, Compra_Bono_Fecha
go

set nocount on;
update NOT_NULL.bono_consulta set bono_turno = Turno_Numero from gd_esquema.Maestra where bono_id = Bono_Consulta_Numero and Compra_Bono_Fecha is null
go

set nocount on;
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

/*TABLA BAJA AFILIADO*/
create table NOT_NULL.baja_afiliado
(
	baja_afiliado_id numeric(18,0) identity (1,1) primary key,
	baja_afiliado_nro numeric(18,0) foreign key references NOT_NULL.afiliado(afiliado_nro),
	baja_afiliado_fecha datetime
)
go


set nocount on;
insert into NOT_NULL.compra_bono (compra_cantidad, compra_afiliado, compra_fecha)
	select count(Compra_Bono_Fecha), afiliado_nro, Compra_Bono_Fecha
	from gd_esquema.Maestra, NOT_NULL.afiliado
	where afiliado_dni = Paciente_Dni and
		Compra_Bono_Fecha is not null and
		Turno_Numero is null and Compra_Bono_Fecha = Bono_Consulta_Fecha_Impresion
	group by Compra_Bono_Fecha, afiliado_nro

	set nocount on;
/*AGREGO USUARIOS, ROLES y FUNCIONES*/
INSERT INTO NOT_NULL.Funcion(funcion_descripcion)
  VALUES ('ABM Rol'), ('ABM Usuario'),('ABM Afiliado'),('ABM Plan'),('ABM Profesional'),('ABM Especialidades'),
    ('Registrar Agenda'),('Comprar Bonos'), ('Pedir Turno'),('Registrar llegada'),('Registrar resultado'),('Listado Estadistico'), ('Cancelar atencion')
GO
  
  set nocount on;
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
  CREATE PROCEDURE NOT_NULL.Afiliado_Add(@Username varchar(50), @Nombre varchar(50),@Apellido varchar(50), @TipoDocumento char(1), @Dni numeric(8,0), @Mail varchar(50),@Telefono varchar(20), @Direccion varchar(50), @CantHijos numeric(2,0), @EstadoCivil char(1), @Fecha datetime, @Plan numeric(18,0), @Sexo char(1))
  AS
	BEGIN
	SET NOCOUNT ON;
		
		INSERT INTO NOT_NULL.afiliado(usuario_id,afiliado_nombre,afiliado_apellido,afiliado_tipo_dni,afiliado_dni,afiliado_mail,afiliado_telefono,afiliado_direccion,afiliado_cant_hijos,afiliado_estado_civil, afiliado_fecha_nac, afiliado_plan, afiliado_sexo)
		VALUES (@Username, @Nombre, @Apellido,@TipoDocumento, @Dni, @Mail, @Telefono,@Direccion, 0, @EstadoCivil, @Fecha, @Plan, @Sexo)
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
  CREATE PROCEDURE NOT_NULL.Afiliado_Modify(@Username varchar(50), @Nombre varchar(50),@Apellido varchar(50), @Dni numeric(8,0), @Mail varchar(50),@Telefono varchar(20), @Direccion varchar(50), @CantHijos numeric(2,0), @EstadoCivil char(1), @Fecha datetime,@Plan numeric(18,0), @Sexo char(1),@cambiarFamilia bit)
  AS
	BEGIN
	SET NOCOUNT ON;
	/*ACA HABRIA QUE TERMINAR ESTO PARA QUE SE SAQUEN LOS BONOS O SE PASEN AL GRUPO FAMILIAR*/
		DECLARE @PlanViejo numeric(18,0);
		declare @nroAfiliadoPrincipal numeric(18,0);
		set @nroAfiliadoPrincipal = (select top 1 afiliado_nro from afiliado where usuario_id = @Username)
		set @PlanViejo = (select top 1 plan_medico.plan_id from plan_medico, afiliado where usuario_id = @Username and afiliado_plan = plan_id) 
		UPDATE NOT_NULL.afiliado
		SET usuario_id = @Username,afiliado_nombre=@Nombre,afiliado_apellido=@Apellido,afiliado_dni=@Dni,afiliado_mail=@Mail,afiliado_telefono=@Telefono,afiliado_direccion=@Direccion,afiliado_cant_hijos = (select afiliado_cant_hijos from afiliado where usuario_id = @Username), afiliado_estado_civil=@EstadoCivil, afiliado_fecha_nac=@Fecha,  afiliado_plan=@Plan, afiliado_sexo=@Sexo
		WHERE usuario_id = @Username
		IF(@PlanViejo <> @Plan)
		BEGIN
			--UPDATE DE LA TABLA BONOS, VER BIEN COMO CARAJO SETEARLE EL VALOR DEL PROXIMO AFILIADO FAMILIAR SI ES QUE TAMPOCO SE CAMBIO DE PLAN
			if(@cambiarFamilia = 1)/*Quiere decir que los bonos quedan inutilizables y tengo que cambiar a la familia de plan tambien*/
			begin
				UPDATE NOT_NULL.afiliado 
				set afiliado_plan = @plan 
				where CAST(afiliado_nro/100 as int) = CAST(@nroAfiliadoPrincipal/100 as int) and afiliado_nro <> @nroAfiliadoPrincipal
				UPDATE NOT_NULL.bono_consulta 
				set bono_utilizado = 'S', bono_afiliado = null
				where CAST(bono_afiliado/100 as int) = CAST(@nroAfiliadoPrincipal/100 as int)  
			end
			else/*QUIERE DECIR QUE LOS BONOS SE LE PASAN AL GRUPO FAMILIAR*/
			begin
				Declare @primerfamiliar numeric(18,0)
				set @primerfamiliar = (select top 1 afiliado_nro from NOT_NULL.afiliado where CAST(afiliado_nro/100 as INT) = CAST(@nroAfiliadoPrincipal/100 as int) and afiliado_nro <> @nroAfiliadoPrincipal)
				UPDATE NOT_NULL.bono_consulta
				set bono_afiliado = @primerfamiliar
				where bono_afiliado = @nroAfiliadoPrincipal
			end
		END
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
	(select afiliado_plan from afiliado where usuario_id = @Username), @Motivo, NOT_NULL.Obtener_Fecha(), @PlanNuevoId)
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
		FROM NOT_NULL.especialidad e, NOT_NULL.tipo_especialidad et, NOT_NULL.medicoXespecialidad mxe
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


--OBTENER AFILIADO SEGUN NRO DE AFILIADO QUE ESTEN ACTIVOS
  create procedure NOT_NULL.Afiliado_GetAfiliadoSegunNro (@nroAfil int)
  as
	begin 
		select afiliado_nombre, afiliado_apellido, afiliado_cant_hijos, afiliado_direccion,afiliado_tipo_dni,  afiliado_dni, afiliado_estado_civil, afiliado_fecha_nac,afiliado_mail, afiliado_nro, afiliado_plan, afiliado_sexo, afiliado_telefono, afiliado.usuario_id
		 from NOT_NULL.afiliado,rolXusuario where afiliado_nro = @nroAfil and afiliado.usuario_id = rolXusuario.usuario_id and rolXusuario.rol_id = 2 and rolXusuario_habilitado = 1
	end
  go

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

/*TRAER ESPECIALIDADES POR MEDICO QUE NO TENGAN AGENDA ASIGNADA*/
  create procedure NOT_NULL.Get_Especialidades_Sin_Agenda(@matricula int)
  as
	begin
		SELECT e.especialidad_codigo, e.especialidad_descripcion, et.tipo_especialidad_descripcion
		FROM NOT_NULL.especialidad e, NOT_NULL.tipo_especialidad et, NOT_NULL.medicoXespecialidad mxe
		WHERE mxe.medxesp_profesional = @matricula AND e.especialidad_codigo = mxe.medxesp_especialidad
			AND et.tipo_especialidad_codigo = e.especialidad_tipo AND mxe.medxesp_agenda is null
	end
  go

  /*LE AGREGO UNA ESPECIALIDAD AL ADMINISTRADOR*/
  set nocount on;
  insert into NOT_NULL.medicoXespecialidad(medxesp_especialidad, medxesp_profesional)
  values (10018, 290)
  go

  
  /*DAR DE BAJA LOGICA UN AFILIADO (ACORDARSE QUE CUANDO SE HACE ESTO TAMBIEN TENGO QUE PONER TODOS LOS TURNOS DEL AFILIADO COMO DISPONIBLES)*/
  create procedure NOT_NULL.Afiliado_Baja_Logica(@UsuarioId varchar(50))
  as
	begin
	set nocount on;
		update NOT_NULL.rolXusuario set rolXusuario_habilitado = 0 where usuario_id = @UsuarioId and rol_id = 2
		--set @ret = (select count(*) from NOT_NULL.rolXusuario where usuario_id = @UsuarioId and rol_id = 2 and rolXusuario_habilitado = 0) 
		--LE DOY DE BAJA A SUS TURNOS Y LOS PONGO COMO DISPONIBLES
		update NOT_NULL.turno set turno_estado = 'D', afiliado_nro = null where (select top 1 usuario_id from afiliado where afiliado_nro = turno.afiliado_nro) = @UsuarioId
		insert into NOT_NULL.baja_afiliado (baja_afiliado_nro, baja_afiliado_fecha) (select top 1 afiliado_nro, GETDATE() from afiliado where usuario_id = @UsuarioId)
	end
  go

  



  /*AGREGAR UN FAMILIAR AL AFIIADO*/
  create procedure NOT_NULL.Afiliado_Agregar_Familiar (@Afiliado_nro_familiar int, @Username varchar(50), @Nombre varchar(50),@Apellido varchar(50),@TipoDocumento char(1), @Dni numeric(8,0), @Mail varchar(50),@Telefono varchar(20), @Direccion varchar(50), @CantHijos numeric(2,0), @EstadoCivil char(1), @Fecha datetime, @Plan numeric(18,0), @Sexo char(1))
  as
	begin;
		DISABLE TRIGGER NOT_NULL.crear_usuario ON NOT_NULL.afiliado
		SET IDENTITY_INSERT NOT_NULL.afiliado ON
			declare @nroafil int;
			set @nroafil = (select top 1 afiliado.afiliado_nro from afiliado where ROUND(afiliado.afiliado_nro/100, 0) = ROUND(@Afiliado_nro_familiar/100, 0) order by afiliado_nro desc) + 1
			--set @nroafil = @Afiliado_nro_familiar + 1
			insert into NOT_NULL.usuario (usuario_id, usuario_cant_intentos, usuario_descripcion, usuario_password, usuario_habilitado)
			values (@Nombre + @Apellido + CAST(@Dni as varchar(8)), 0, 'Afiliado',HASHBYTES('SHA2_256', 'afiliado'), 1)
			insert into NOT_NULL.afiliado (afiliado_nro, usuario_id, afiliado_nombre, afiliado_apellido, afiliado_tipo_dni,afiliado_dni, afiliado_cant_hijos, afiliado_direccion, afiliado_estado_civil, afiliado_fecha_nac, afiliado_mail, afiliado_plan, afiliado_sexo, afiliado_telefono)
		     values(@nroafil, @Nombre + @Apellido + CAST(@Dni as varchar(8)), @Nombre, @Apellido, @TipoDocumento ,@Dni, @CantHijos, @Direccion, @EstadoCivil, @Fecha, @Mail, @Plan, @Sexo, @Telefono) 
			insert into NOT_NULL.rolXusuario (rolXusuario_habilitado, rol_id, usuario_id) 
			values (1, 2, @Nombre + @Apellido + CAST(@Dni as varchar(8)))
			SET IDENTITY_INSERT NOT_NULL.afiliado OFF;
		ENABLE TRIGGER NOT_NULL.crear_usuario ON NOT_NULL.afiliado
	end 
  go


  --AGREGAR AGENDA
  CREATE PROCEDURE NOT_NULL.Agenda_Agregar(@matricula int, @especialidad varchar(255), @fecha_inicio datetime, @fecha_fin datetime, @id_agenda int OUTPUT)
  AS BEGIN
	Declare @especialidad_id numeric(18,0);
	set @especialidad_id = (Select top 1 especialidad.especialidad_codigo from especialidad where especialidad.especialidad_descripcion = @especialidad);
	INSERT INTO NOT_NULL.Agenda(agenda_fecha_inicio,agenda_fecha_fin)
	VALUES(@fecha_inicio, @fecha_fin)
	
	UPDATE NOT_NULL.medicoXespecialidad
	SET medxesp_agenda = @@IDENTITY
	WHERE medxesp_profesional = @matricula 
		AND medxesp_especialidad = (SELECT TOP 1 e.especialidad_codigo 
										FROM NOT_NULL.especialidad e
										WHERE e.especialidad_descripcion = @especialidad)
	
	SET @id_agenda = @@IDENTITY
	END
  GO
  
  --AGREGAR FRANJA
  CREATE PROCEDURE NOT_NULL.Franja_Agregar(@id_agenda int, @dia int, @hora_inicio int, @minuto_inicio int, @hora_fin int, @minuto_fin int)
  AS BEGIN;
	--SET IDENTITY_INSERT NOT_NULL.Agenda ON;

	DECLARE @horaInicio int
	DECLARE @minutoInicio int
	DECLARE @horaFin int
	DECLARE @minutoFin int

	DECLARE @totalMinutos int

	--Lo inicializo con los minutos ingresados
	SET @totalMinutos = (@hora_fin*60 + @minuto_fin) - (@hora_inicio*60 + @minuto_inicio)

	DECLARE cursorFranjas CURSOR
	FOR	(SELECT f.hora_inicio,f.minuto_inicio,f.hora_fin,f.minuto_fin
		 FROM NOT_NULL.agenda a, NOT_NULL.franja_horaria f
		 WHERE f.agenda_id = a.agenda_id)

	OPEN cursorFranjas
	FETCH cursorFranjas INTO @horaInicio,@minutoInicio,@horaFin,@minutoFin

	--Le sumo todos los minutos que ya tenga
	WHILE(@@FETCH_STATUS = 0)
	BEGIN
		SET @totalMinutos = @totalMinutos + (@horaFin*60 + @minutoFin) - (@horaInicio*60 + @minutoInicio)

		FETCH cursorFranjas INTO @horaInicio,@minutoInicio,@horaFin,@minutoFin
	END

	CLOSE cursorFranjas
	DEALLOCATE cursorFranjas

	--Si no se excede de las 48 horas
	IF(@totalMinutos <= 48*60)
	BEGIN
		INSERT INTO NOT_NULL.franja_horaria(agenda_id, dia, hora_inicio, minuto_inicio, hora_fin, minuto_fin) 
		values(@id_agenda,@dia,@hora_inicio,@minuto_inicio,@hora_fin,@minuto_fin);
		--SET IDENTITY_INSERT NOT_NULL.Agenda OFF;
	END
  END
  GO
  
  CREATE PROCEDURE NOT_NULL.Get_medxesp_id(@matricula int, @especialidad int)
  AS BEGIN
	
	SELECT TOP 1 mxe.medxesp_id  FROM NOT_NULL.profesional p, NOT_NULL.medicoXespecialidad mxe
	WHERE p.profesional_matricula = @matricula
		AND mxe.medxesp_especialidad = @especialidad
	
  END
  GO

  --drop procedure NOT_NULL.Turno_Agregar
  CREATE PROCEDURE NOT_NULL.Turno_Agregar(@matricula int, @especialidad int, @fecha datetime)
  AS BEGIN
	DECLARE @medxesp_id int
	DECLARE @turnonro numeric(18,0)
	SET @turnonro = (SELECT TOP 1 turno.turno_nro from turno order by turno.turno_nro desc) +1
	SET @medxesp_id = (SELECT TOP 1 mxe.medxesp_id
				   FROM NOT_NULL.medicoXespecialidad mxe
				   WHERE mxe.medxesp_especialidad = @especialidad and mxe.medxesp_profesional = @matricula)
	if((select count(*) from turno where turno.turno_fecha = @fecha and turno.turno_medico_especialidad_id = @medxesp_id) = 0)
	begin
		if((select count(*) from turno where turno_fecha =  @fecha and turno.turno_medico_especialidad_id = 
		(select top 1 medicoXespecialidad.medxesp_id from medicoXespecialidad where medxesp_profesional = @matricula and medxesp_id <> @medxesp_id))=0)
		begin
			INSERT INTO NOT_NULL.turno(turno_nro,turno_fecha,turno_medico_especialidad_id)
			values(@turnonro,@fecha,@medxesp_id)
		end
	end
  END
  GO
  
  
  set nocount on;
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

  create procedure NOT_NULL.Get_Especialidades_All_2
  as
	begin
		select especialidad_codigo, especialidad_descripcion, tipo_especialidad_descripcion
			from NOT_NULL.especialidad, NOT_NULL.tipo_especialidad
			where tipo_especialidad_codigo = especialidad_tipo
	end
  go

  create procedure NOT_NULL.Get_Turnos_Today
  as
	begin
		select * from NOT_NULL.turno where turno_fecha = CONVERT(DATE, NOT_NULL.Obtener_Fecha());
	end
  go
    
  /* --------------------------------------------------------------------------------------------------------------------- */
  CREATE PROCEDURE NOT_NULL.reservarTurno_GetByFilerProfesional @afiliado varchar(20), @nro_turno varchar(20)
  AS
	BEGIN
	SET NOCOUNT ON;
	UPDATE NOT_NULL.turno
	SET afiliado_nro = @afiliado,
		turno_estado = 'R'
	 WHERE turno_nro = @nro_turno
	END
   GO   


  -- FILTRADO DE DIAS DE TURNOS SEGUN CODIGO_PROFESIONAL
  CREATE PROCEDURE NOT_NULL.turnos_GetByFilerProfesional @profesional int, @especialidad numeric(18,0) /* fecha_archivo */
  AS
	BEGIN
	SET NOCOUNT ON;
	SELECT str(turno_nro) as turno,
		   str(day(turno_fecha)) as dia,
		   str(month(turno_fecha)) as mes,
		   CONVERT(nvarchar(MAX), turno_fecha, 8) as hora
	FROM not_null.turno
	 WHERE turno_fecha >= CONVERT(date,NOT_NULL.Obtener_Fecha()) /* fecha_archivo */
	  and afiliado_nro is null 
	  and turno_estado = 'D' 
	  and turno_medico_especialidad_id = (select top 1 medxesp_id from NOT_NULL.medicoXespecialidad where medxesp_profesional = @profesional and medxesp_especialidad = @especialidad)
	END
  GO   

  --FILTRADO DE PROFESIONALES POR ESPECIALIDAD - OK
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
									 SELECT medxesp_profesional 
									 FROM NOT_NULL.medicoXespecialidad 
									 WHERE medxesp_especialidad = str(@especialidad)
									 )	
	END
  GO

-- FILTRADO DE ESPECIALIDADES POR LIKE NOMBRE_ESPECIALIDAD - OK
CREATE PROCEDURE NOT_NULL.especialidades_GetByFilerEspecialidad (@especialidad varchar(20))
  AS
	BEGIN
	SET NOCOUNT ON;
		SELECT especialidad_codigo, especialidad_descripcion, str(especialidad_tipo) as especialidad_tipo FROM NOT_NULL.especialidad 
		WHERE especialidad_descripcion LIKE ('%' + @especialidad + '%')
	END
  GO  
  
  /* ------------------------------------------------------------------------------------------------------------------------------*/
   -- Registrar Compra Bono
  CREATE PROCEDURE NOT_NULL.Comprar_Bono(@cantidad int, @precio int, @afiliado numeric(18,0), @fecha datetime, @plan numeric(18,0))
  AS
	BEGIN
	SET NOCOUNT ON;
	declare @bono_id numeric(18,0)
	declare @aux int
	set @bono_id = (select top 1 bono_id from NOT_NULL.bono_consulta order by bono_id desc)
	set @aux = 1

	while @aux <= @cantidad
	Begin
		INSERT INTO NOT_NULL.bono_consulta(bono_id, bono_afiliado, bono_fecha_compra, bono_plan, bono_utilizado)
			VALUES (@bono_id + @aux, @afiliado, @fecha, @plan, 'N')
		set @aux = @aux + 1
	End

	INSERT INTO NOT_NULL.compra_bono(compra_cantidad, compra_precio, compra_afiliado, compra_fecha)
		VALUES (@cantidad, @precio, @afiliado, @fecha)
	END
  GO


  --	Top 5 de las especialidades que más se registraron cancelaciones, tanto de afiliados como de profesionales.
  --	No testeado
CREATE PROCEDURE NOT_NULL.listado_Mas_Cancelaciones_Especialidad (@fecha1 datetime, @fecha2 datetime)
as
	begin
		 select top 5 especialidad_descripcion, count(cancel_turno) as cantidad_cancelaciones
			from NOT_NULL.especialidad, NOT_NULL.medicoXespecialidad, NOT_NULL.cancelacion_turno, NOT_NULL.turno
			where turno_nro = cancel_turno and turno_medico_especialidad_id = medxesp_id and especialidad_codigo = medxesp_especialidad 
				and cancel_fecha >= @fecha1 and cancel_fecha < @fecha2
			group by especialidad_descripcion
			order by count(cancel_turno) desc
	end
go

CREATE PROCEDURE NOT_NULL.listado_Mas_Cancelaciones_Especialidad_Afiliado (@fecha1 datetime, @fecha2 datetime)
as
	begin
		 select top 5 especialidad_descripcion, count(cancel_turno) as cantidad_cancelaciones
			from NOT_NULL.especialidad, NOT_NULL.medicoXespecialidad, NOT_NULL.cancelacion_turno, NOT_NULL.turno
			where turno_nro = cancel_turno and turno_medico_especialidad_id = medxesp_id and especialidad_codigo = medxesp_especialidad 
				and cancel_fecha >= @fecha1 and cancel_fecha < @fecha2
				and cancel_afiliado is not null
			group by especialidad_descripcion
			order by count(cancel_turno) desc
	end
go


CREATE PROCEDURE NOT_NULL.listado_Mas_Cancelaciones_Especialidad_Profesional (@fecha1 datetime, @fecha2 datetime)
as
	begin
		 select top 5 especialidad_descripcion, count(cancel_turno) as cantidad_cancelaciones
			from NOT_NULL.especialidad, NOT_NULL.medicoXespecialidad, NOT_NULL.cancelacion_turno, NOT_NULL.turno
			where turno_nro = cancel_turno and turno_medico_especialidad_id = medxesp_id and especialidad_codigo = medxesp_especialidad 
				and cancel_fecha >= @fecha1 and cancel_fecha < @fecha2
				and cancel_profesional is not null
			group by especialidad_descripcion
			order by count(cancel_turno) desc
	end
go



  --           Top 5 de los profesionales más consultados por Plan, detallando también bajo que Especialidad
CREATE PROCEDURE NOT_NULL.listado_Profesionales_Consultados (@fecha1 datetime, @fecha2 datetime, @plan varchar(255))
as
	begin
		 select top 5 profesional_matricula, profesional_nombre, profesional_apellido, especialidad_descripcion, count(turno_nro) as cantidad_consultas
		 	from NOT_NULL.profesional, NOT_NULL.plan_medico, NOT_NULL.especialidad, NOT_NULL.medicoXespecialidad, NOT_NULL.turno, NOT_NULL.bono_consulta
			where plan_descripcion = @plan
				and medxesp_especialidad = especialidad_codigo and medxesp_profesional = profesional_matricula
				and turno_medico_especialidad_id = medxesp_id and turno_fecha >= @fecha1 and turno_fecha < @fecha2
				and turno_estado = 'U' and bono_turno = turno_nro and bono_plan = plan_id
			group by profesional_matricula, profesional_nombre, profesional_apellido, especialidad_descripcion
			order by count(turno_nro) desc
	end
go

	--	Top 5 de los profesionales con menos horas trabajadas filtrando por Plan y Especialidad
CREATE PROCEDURE NOT_NULL.listado_Profesionales_Menos_Horas (@fecha1 datetime, @fecha2 datetime, @especialidad varchar(255))
as
	begin
	 select top 5 profesional_matricula, profesional_nombre, profesional_apellido, (count(turno_nro)*0.5) as cantidad_horas
		 	from NOT_NULL.profesional, NOT_NULL.especialidad, NOT_NULL.medicoXespecialidad, NOT_NULL.turno, NOT_NULL.bono_consulta
			where especialidad_descripcion = @especialidad
				and medxesp_especialidad = especialidad_codigo and medxesp_profesional = profesional_matricula
				and turno_medico_especialidad_id = medxesp_id and turno_fecha >= @fecha1 and turno_fecha < @fecha2
				and turno_estado = 'U' and bono_turno = turno_nro
			group by profesional_matricula, profesional_nombre, profesional_apellido
			order by count(turno_nro) asc
	end
go


--		Top 5 de los afiliados con mayor cantidad de bonos comprados, detallando si pertenece a un grupo familiar
 CREATE PROCEDURE NOT_NULL.listado_Afiliado_Mas_Bonos (@fecha1 datetime, @fecha2 datetime)			
 as
	Begin
		select top 5 afil1.afiliado_nro, afil1.afiliado_nombre, afil1.afiliado_apellido, count(bono_id) as cantidad_bonos,
		( select case when isnull(count(*), 0) = 0 then 'NO' else 'SI' end
			from NOT_NULL.afiliado afil2
			where afil2.afiliado_nro <> afil1.afiliado_nro and ROUND(afil1.afiliado_nro / 100, 0) = ROUND(afil2.afiliado_nro / 100, 0) ) as pertenece_grupo_familiar
		from NOT_NULL.afiliado afil1, NOT_NULL.bono_consulta
		where bono_afiliado = afiliado_nro
			and bono_fecha_compra >= @fecha1 and bono_fecha_compra < @fecha2
		group by afil1.afiliado_nro, afil1.afiliado_nombre, afil1.afiliado_apellido
		order by count(bono_id) desc
	End
 go


--		Top 5 de las especialidades de médicos con más bonos de consultas utilizados
 CREATE PROCEDURE NOT_NULL.listado_Especialidad_Mas_Bonos (@fecha1 datetime, @fecha2 datetime)
 as
	Begin
		select top 5 especialidad_descripcion, count(bono_id) as cantidad_bonos
		from NOT_NULL.especialidad, NOT_NULL.bono_consulta, NOT_NULL.turno, NOT_NULL.medicoXespecialidad
		where bono_utilizado = 'S' and bono_fecha_compra >= @fecha1 and bono_fecha_compra < @fecha2
			and bono_turno = turno_nro and turno_medico_especialidad_id = medxesp_id and medxesp_especialidad = especialidad_codigo
		group by especialidad_descripcion
		order by count(bono_id) desc
	End
 go


 /*TRAIGO TODOS LOS TURNOS DEL DIA QUE YA LLEGARON*/
 create procedure NOT_NULL.GetTurnosDiaLlegaron(@fecha datetime, @matricula int, @especialidad int)
 as
	begin
		declare @medespid int
		set @medespid = (select top 1 medicoXespecialidad.medxesp_id from medicoXespecialidad where medicoXespecialidad.medxesp_especialidad = @especialidad and medicoXespecialidad.medxesp_profesional = @matricula)
		select * from turno where YEAR(turno_fecha) = year(@fecha) and MONTH(turno_fecha) = MONTH(@fecha) and DAY(turno_fecha) = DAY(@fecha)
		 and turno.turno_estado = 'L' and turno_medico_especialidad_id = @medespid
	end
 go

 /*REGISTRO UN RESULTADO*/
 create procedure NOT_NULL.Registrar_Resultado(@sintomas varchar(255), @enfermedades varchar(255), @turnoid numeric(18,0), @tiempo bit)
 as 
	begin
		update NOT_NULL.turno set turno_estado = 'U', turno_tiempo = @tiempo
		where turno_nro = @turnoid
		insert into NOT_NULL.consulta (consulta_sintomas,consulta_enfermedades, consulta_turno) values ( @sintomas, @enfermedades, @turnoid)  
	end
 go

 /*TRAIGO LOS TURNOS DE UN PROFESIONAL QUE ESTAN RESERVADOS*/
 create procedure NOT_NULL.Get_Turnos_Prof_Reservados(@medxespid int, @fecha datetime, @nroafiliado int)
 as
	begin
		select * from turno where turno_medico_especialidad_id = @medxespid and YEAR(turno_fecha) = YEAR(@fecha)
		and MONTH(turno_fecha) = MONTH(@fecha) and DAY(turno_fecha) = DAY(@fecha) and LEFT(afiliado_nro, len(@nroafiliado)) = @nroafiliado and turno_estado = 'R'
	end
 go

 /*ME FIJO SI EL AFILIADO TENIA BONOS*/
 create procedure NOT_NULL.Get_Bonos_Afiliado(@nroafiliado int)
 as
	begin
		select * from NOT_NULL.bono_consulta where (CONVERT(int ,bono_afiliado))/100 = @nroafiliado/100 and bono_utilizado = 'N' and bono_plan = (select afiliado_plan from afiliado where afiliado_nro = @nroafiliado)
	end
 go


 /*REGISTRO LA LLEGADA DE UN AFILIADO A UN TURNO*/
 create procedure NOT_NULL.Registrar_Llegada(@nroafiliado int, @nroturno numeric(18,0), @fecha datetime) 
 as
	begin
		declare @nrobonoconsulta int
		set @nrobonoconsulta = isnull((select top 1 (bono_nro_bono_afiliado+1) from NOT_NULL.bono_consulta where
		NOT_NULL.bono_consulta.bono_afiliado = @nroafiliado order by bono_nro_bono_afiliado desc),1)
		update NOT_NULL.turno set turno_hora_llegada = @fecha, turno_estado = 'L' where turno_nro = @nroturno
		declare @primerBono int
		set @primerBono = (select top 1 bono_consulta.bono_id from bono_consulta where bono_utilizado = 'N' and
		(CONVERT(int ,bono_afiliado))/100 = @nroafiliado/100 and bono_fecha_compra is not null)
		update  NOT_NULL.bono_consulta set bono_utilizado = 'S', bono_turno = @nroturno, bono_nro_bono_afiliado = @nrobonoconsulta
		where bono_id = @primerBono 
	end
 go

 /*CANCELO EL TURNO DEL AFILIADO*/
 create procedure NOT_NULL.Cancelar_Turno_Afiliado(@nroturno numeric(18,0), @nroafiliado numeric(18,0), @fecha datetime, @motivo varchar(255), @tipo char(1))
 as
	begin
		update NOT_NULL.turno set turno_estado = 'D' , afiliado_nro = null where turno_nro = @nroturno and afiliado_nro = @nroafiliado
		insert into NOT_NULL.cancelacion_turno (cancel_afiliado, cancel_fecha, cancel_motivo, cancel_tipo, cancel_turno)
		values(@nroafiliado, @fecha, @motivo, LEFT(@tipo, 1), @nroturno)
	end
 go


 /*TRAIGO TODOS LOS TURNOS DE UN AFILIADO*/
 create procedure NOT_NULL.Turnos_Afiliado(@nroafiliado numeric(18,0), @fecha datetime)
 as
	begin
		select * from turno where afiliado_nro = @nroafiliado and YEAR(turno_fecha) = YEAR(@fecha) and MONTH(turno_fecha) = MONTH(@fecha)
		and DAY(turno_fecha) = DAY(@fecha) and turno_estado = 'R'
	end
 go


/*TRAIGO TODOS LOS TURNOS DE UN AFILIADO MAYOR A FECHA*/
 create procedure NOT_NULL.Turnos_Afiliado_Mayor(@nroafiliado numeric(18,0), @fecha datetime)
 as
	begin
		select * from turno where afiliado_nro = @nroafiliado and turno_fecha > @fecha and turno_estado = 'R'
	end
 go


 /*OBTENGO TODOS LOS DIAS QUE TIENEN TURNO*/
 create procedure NOT_NULL.Get_Dias_Turno_Prof(@matricula int)
 as
	begin 
		select Convert(date, turno_fecha) as turno_fecha from NOT_NULL.turno, NOT_NULL.medicoXespecialidad
		where turno_medico_especialidad_id = medxesp_id and medxesp_profesional = @matricula
			and (turno_estado = 'D' or turno_estado = 'R') and turno_fecha >= Convert(date, NOT_NULL.Obtener_Fecha()+1)
		group by Convert(date, turno_fecha)
		order by Convert(date, turno_fecha)
	end
 go

 /*OBTENGO TODAS LAS FRANJAS DEL PROFESIONAL*/
 create procedure NOT_NULL.Get_Franjas_Profesional(@matricula int)
 as
	begin
		select * from NOT_NULL.franja_horaria
		where franja_horaria.agenda_id = (select agenda_id from NOT_NULL.agenda where agenda_id = (select medxesp_agenda from NOT_NULL.medicoXespecialidad where medxesp_profesional = @matricula))
		and franja_cancelada = 0 
	end
 go

 /*CANCELO EL TURNO DEL PROFESIONAL*/
 create procedure NOT_NULL.Cancelar_Turnos_Profesional(@motivo varchar(255), @tipo char(1),@matricula int, @fecha datetime)
 as
	begin
	update NOT_NULL.turno set turno_estado = 'C', afiliado_nro = null 
		where YEAR(turno_fecha) = YEAR(@fecha) and MONTH(turno_fecha)=MONTH(@fecha) and DAY(turno_fecha)=DAY(@fecha)
			and turno_medico_especialidad_id = (select medicoXespecialidad.medxesp_id from NOT_NULL.medicoXespecialidad where medxesp_profesional = @matricula)
	insert into NOT_NULL.cancelacion_turno (cancel_fecha, cancel_motivo, cancel_profesional, cancel_tipo, cancel_turno)
		values(NOT_NULL.Obtener_Fecha(), @motivo +' : Fue una cancelacion por dia', @matricula, @tipo, null)

	end
 go


create procedure NOT_NULL.Cancelar_Turnos_ProfxFranja(@motivo varchar(255), @tipo char(1), @matricula int, @fecha datetime, @horain time, @horafin time)
 as
	begin
		declare @turno numeric(18,0)
		declare @hora int
		declare @minuto int
		set @hora = DATEPART( hour, @horain )
		set @minuto = DATEPART( minute, @horain )
		while (@hora <= DATEPART( hour, @horafin ) and @minuto <= DATEPART( minute, @horafin ) and @hora < 24 and @hora >= 0 )
		Begin
			set @turno = isnull(( select top 1 turno_nro from NOT_NULL.turno, NOT_NULL.medicoXespecialidad
				where turno_medico_especialidad_id = medxesp_id and medxesp_profesional = @matricula
					and day(turno_fecha) = day(@fecha) and month(turno_fecha) = month(@fecha) and year(turno_fecha) = year(@fecha)
					and Convert(date, turno_fecha) > Convert(date, NOT_NULL.Obtener_Fecha())
					and	DATEPART( hour, Convert(time, turno_fecha)) = @hora and	DATEPART( minute, Convert(time, turno_fecha)) = @minuto), -1)
			
			if(@turno <> -1)
			Begin
				update NOT_NULL.turno set turno_estado = 'C', afiliado_nro = null where turno_nro = @turno
				insert into NOT_NULL.cancelacion_turno (cancel_fecha, cancel_motivo, cancel_profesional, cancel_tipo, cancel_turno)
					values(NOT_NULL.Obtener_Fecha(), @motivo+' :Fue una cancelacion por franja', @matricula, @tipo, @turno)
			End

			if @minuto = 0
			Begin
				set @minuto = 30
			End
			else
			Begin
				set @minuto = 0
				set @hora = @hora + 1
			End

		End
	end
 go


 
create procedure NOT_NULL.Cancelar_Turnos_Varios_Dias(@motivo varchar(255), @tipo char(1), @matricula int, @fecha_desde datetime, @fecha_hasta datetime)
 as
	begin
		
		declare @horain time
		declare @horafin time
		set @horain = '0:00'
		set @horafin= '23:59'
		declare @fecha_aux datetime
		set @fecha_aux = @fecha_desde
		while (@fecha_aux <= @fecha_hasta)
		Begin
			exec NOT_NULL.Cancelar_Turnos_ProfxFranja @motivo, @tipo, @matricula, @fecha_aux, @horain, @horafin
			set @fecha_aux = @fecha_aux + 1
		End
	end
 go
 
 
 /*Fechas config*/
 CREATE TABLE NOT_NULL.Fecha_Config(
	id int primary key,
	fecha datetime,
	now_viejo datetime
 )
 GO
 
 CREATE PROCEDURE NOT_NULL.Reestablecer_Fecha (@fecha datetime, @now_viejo datetime)
 AS BEGIN
 
	--Borro el valor anterior
	DELETE FROM NOT_NULL.Fecha_Config
	
	INSERT INTO NOT_NULL.Fecha_Config (id,fecha,now_viejo)
	VALUES(1,@fecha,@now_viejo)
	
 END
 GO
 
 CREATE FUNCTION NOT_NULL.Obtener_Fecha()
 RETURNS datetime
 AS BEGIN
	
	DECLARE @fecha_tabla datetime
	DECLARE @now_viejo datetime
	
	SET @fecha_tabla = (SELECT f.fecha FROM NOT_NULL.Fecha_Config f
						WHERE f.id=1)
	SET @now_viejo = (SELECT f.now_viejo FROM NOT_NULL.Fecha_Config f
					  WHERE f.id=1)
	
	--retorno la fecha tabla + dif entre now y el now_viejo
	RETURN DATEADD(minute, DATEDIFF(minute,@now_viejo,GETDATE()), @fecha_tabla )
	
END
GO
