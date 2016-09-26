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

insert into NOT_NULL.profesional
(profesional_nombre, profesional_apellido, profesional_dni, profesional_direccion, profesional_telefono, profesional_mail, profesional_fecha_nacimiento, profesional_sexo, profesional_tipo_doc)
select Medico_Nombre, Medico_Apellido, Medico_Dni, Medico_Direccion, Medico_Telefono, Medico_Mail, Medico_Fecha_Nac, 'N', 'D' 
	from gd_esquema.Maestra
	where Medico_Nombre <> 'NULL'
	group by Medico_Nombre, Medico_Apellido, Medico_Dni, Medico_Direccion, Medico_Telefono, Medico_Mail, Medico_Fecha_Nac 
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
	 usuario_id varchar(50) foreign key references NOT_NULL.usuario(usuario_id),
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
	 afiliado_plan numeric(18,0) foreign key references NOT_NULL.plan_medico(plan_id),
	 afiliado_habilitado character(1),
	 afiliado_cant_bonos_consulta numeric(18,0)
)
go

create trigger NOT_NULL.aumentar_cantidad_hijos on NOT_NULL.afiliado for insert
as
Begin
	declare @afiliado_nro numeric(18,0)
	select @afiliado_nro = afiliado_nro from inserted
	set @afiliado_nro = ROUND(@afiliado_nro / 100, 0)

	update NOT_NULL.afiliado set afiliado_cant_hijos = afiliado_cant_hijos + 1
		where ROUND(afiliado_nro/100, 0) = @afiliado_nro
		and afiliado_nro - 1 = ROUND(afiliado_nro/100, 0)*100
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


insert into NOT_NULL.afiliado
(afiliado_nombre, afiliado_apellido, afiliado_dni, afiliado_estado_civil, 
afiliado_sexo, afiliado_fecha_nac, afiliado_telefono, afiliado_mail, afiliado_direccion, afiliado_cant_hijos, afiliado_cant_bonos_consulta, afiliado_habilitado, afiliado_plan)
select Paciente_Nombre, Paciente_Apellido, Paciente_Dni, 'N', 'N', Paciente_Fecha_Nac, Paciente_Telefono, Paciente_Mail, Paciente_Direccion, 0, 0, 'S', Plan_Med_Codigo 
	from gd_esquema.Maestra
	group by Paciente_Nombre, Paciente_Apellido, Paciente_Dni, Paciente_Fecha_Nac, Paciente_Telefono, Paciente_Mail, Paciente_Direccion, Plan_Med_Codigo
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
	turno_hora_llegada time(7) NULL,
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



insert into NOT_NULL.turno(turno_nro, afiliado_nro, turno_fecha, turno_estado, /*turno_hora_llegada,*/ turno_sintomas , turno_enfermedades, turno_medico_especialidad_id)
select Turno_Numero, afiliado_nro, Turno_Fecha, 'N', Consulta_Sintomas, Consulta_Enfermedades, medxesp_id
	from gd_esquema.Maestra, NOT_NULL.afiliado, NOT_NULL.medicoXespecialidad, NOT_NULL.profesional
	where afiliado_dni = Paciente_Dni and medxesp_especialidad = Especialidad_Codigo and medXesp_profesional = profesional_matricula
		and profesional_dni = Medico_Dni
		and Bono_Consulta_Fecha_Impresion is not null and Bono_Consulta_Numero is not null and Turno_Numero is not null  order by Turno_Numero 
go




/*CREAR TABLA CANCELACION TURNOS*/
CREATE TABLE NOT_NULL.cancelacion_turno(
	cancelacion_id int NOT NULL,
	afiliado_nro numeric(18, 0) NOT NULL,
	profesional_matricula int NOT NULL,
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
	agenda_id int PRIMARY KEY IDENTITY(0,1),
	agenda_medxesp int NOT NULL foreign key references NOT_NULL.medicoXespecialidad(medxesp_id)
)
GO

CREATE TABLE NOT_NULL.franja_horaria(
	franja_id int PRIMARY KEY IDENTITY(0,1),
	agenda int NOT NULL foreign key references NOT_NULL.agenda,
	dia int NOT NULL CHECK(dia >=1 AND dia <=7),
	hora_inicio int NOT NULL CHECK(hora_inicio<24 AND hora_inicio>=0),
	minuto_inicio int NOT NULL CHECK(minuto_inicio<60 AND minuto_inicio>=0),
	hora_fin int NOT NULL CHECK(hora_fin<24 AND hora_fin>=0),
	minuto_fin int NOT NULL CHECK(minuto_fin<60 AND minuto_fin>=0)	)
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
	 bono_utilizado character(1)
)
go

insert into NOT_NULL.bono_consulta (bono_id, bono_afiliado, bono_plan, bono_fecha_compra, bono_utilizado)
select Bono_Consulta_Numero, afiliado_nro, Plan_Med_Codigo, Compra_Bono_Fecha, 'S'
	from gd_esquema.Maestra, NOT_NULL.afiliado
	where Bono_Consulta_Numero is not null and Compra_Bono_Fecha is not null and afiliado_dni = Paciente_Dni
	order by Bono_Consulta_Numero, Paciente_Dni, Plan_Med_Codigo, Compra_Bono_Fecha
go

update NOT_NULL.bono_consulta set bono_turno = Turno_Numero from gd_esquema.Maestra where bono_id = Bono_Consulta_Numero and Compra_Bono_Fecha is null

SET NOCOUNT ON 
go

create procedure NOT_NULL.contarBonos
as
Begin
	declare @afiliado numeric(18,0)
	declare unCursor cursor for select afiliado_nro from NOT_NULL.afiliado
	open unCursor
	fetch next from unCursor into @afiliado
	while @@FETCH_STATUS = 0
	Begin
		update NOT_NULL.afiliado set afiliado_cant_bonos_consulta = (select count(*) from NOT_NULL.bono_consulta where bono_afiliado = @afiliado)
			where afiliado_nro = @afiliado
		fetch next from unCursor into @afiliado
	End
	close unCursor
	deallocate unCursor
End
go


exec NOT_NULL.contarBonos		-- comentar esto para q no tarde
go


create trigger NOT_NULL.aumentar_cantidad_bonos_afiliado on NOT_NULL.bono_consulta after insert
as
Begin
	declare @bono_afiliado numeric(18,0)
	if (select count(*) from inserted) = 1
	Begin
		select @bono_afiliado = bono_afiliado from inserted
		update NOT_NULL.afiliado set afiliado_cant_bonos_consulta = afiliado_cant_bonos_consulta + 1
				where afiliado_nro = @bono_afiliado
	End
End
go

/*AGREGO USUARIOS, ROLES y FUNCIONES*/
INSERT INTO NOT_NULL.Funcion(funcion_descripcion)
  VALUES ('ABM Rol'), ('ABM Usuario'),('ABM Afiliado'),('ABM Plan'),('ABM Profesional'),('ABM Especialidades'),
    ('Registrar Agenda'),('Comprar Bonos'), ('Pedir Turno'),('Registrar llegada'),('Registrar resultado'),('Listado Estadistico'), ('Cancelar atencion')
GO
  Insert INTO NOT_NULL.Rol(rol_descripcion)
  VALUES ('Administrador'), ('Afiliado'), ('Profesional')
GO
  -- Roles administrador
  INSERT INTO NOT_NULL.funcionXrol(rol_id, funcion_id)
  VALUES (1, 1),(1, 2),(1, 3),(1, 4),(1, 5),(1, 6), (1,10), (1,12)
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
  VALUES ('admin', 1), ('admin', 2), ('admin', 3)
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
  INSERT INTO NOT_NULL.afiliado(afiliado_nombre, afiliado_apellido, afiliado_dni, afiliado_mail, afiliado_telefono, afiliado_direccion, afiliado_cant_hijos, afiliado_cant_bonos_consulta, afiliado_fecha_nac, afiliado_estado_civil, afiliado_plan, afiliado_sexo, usuario_id)
  VALUES ('admin', 'istrador', 32405354, 'admin@gdd.com', '+5491168489235', 'Avenida Leandro N. Alem 5458 piso 18 depto Q 1558', 0, 0, CONVERT(DATETIME,1995-07-12), 'S',NULL, 'M', 'admin')
  GO
  --CREO UN USUARIO PROFESIONAL PARA EL ADMIN
  INSERT INTO NOT_NULL.profesional(profesional_nombre, profesional_apellido, profesional_dni, profesional_tipo_doc, profesional_telefono, profesional_direccion, profesional_fecha_nacimiento, profesional_sexo, profesional_mail,  usuario_id)
  VALUES ('admin', 'istrador', 32405354, 'D',  '+5491168489235', 'Avenida Leandro N. Alem 5458 piso 18 depto Q 1558', CONVERT(DATETIME,1995-07-12), 'M','admin@gdd.com', 'admin')
  GO
  --LOGIN PARA LOS USUARIOS
  CREATE PROCEDURE NOT_NULL.Usuario_LogIn (@username varchar(20), @password varchar(20))
  AS
  BEGIN
   SET NOCOUNT ON;
   SELECT * FROM NOT_NULL.Usuario WHERE usuario_id = @username AND usuario_password =  HASHBYTES('SHA2_256', @password) And usuario_habilitado = 1
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
  CREATE PROCEDURE NOT_NULL.UsuarioXRol_GetRolesByUser (@username varchar(20))
  AS
	BEGIN
		SET NOCOUNT ON;
		SELECT * FROM NOT_NULL.Rol WHERE rol_id in (SELECT rol_id FROM NOT_NULL.rolXusuario WHERE usuario_id = @username and rolXusuario_habilitado = 1)
	END
  GO

  --OBTENER TODAS LAS FUNCIONES DE UN ROL
  CREATE PROCEDURE NOT_NULL.RolXFuncion_GetFunByRol (@rol int)
  AS
	BEGIN
		SET NOCOUNT ON;
		SELECT * FROM NOT_NULL.Funcion WHERE funcion_id in (SELECT funcion_id FROM NOT_NULL.funcionXrol WHERE rol_id = @rol)
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
			SET funcionXrol_activo=0 WHERE funcion_id = @funcion AND rol_id = @rol  
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
  CREATE PROCEDURE NOT_NULL.Usuario_Add(@Username varchar(20), @Password varchar(20))
  AS
	BEGIN
	SET NOCOUNT ON;
		INSERT INTO NOT_NULL.Usuario (usuario_id, usuario_password)
		VALUES (@Username, HASHBYTES('SHA2_256', @Password))
	END
  GO

  --CREAR PROFESIONAL
  CREATE PROCEDURE NOT_NULL.Profesional_Add(@Username varchar(50), @Nombre varchar(50),@Apellido varchar(50),@Dni numeric(8,0), @TipoDoc char(1), @Mail varchar(50), @Telefono varchar(20), @Direccion varchar(50), @Sexo char(1), @FechaNacimiento datetime)
  AS
	BEGIN
	SET NOCOUNT ON;
		INSERT INTO NOT_NULL.profesional(usuario_id, profesional_nombre, profesional_apellido,profesional_dni, profesional_tipo_doc, profesional_mail, profesional_telefono, profesional_direccion, profesional_sexo,profesional_fecha_nacimiento)
		VALUES (@Username,@Nombre, @Apellido, @Dni, @TipoDoc, @Mail, @Telefono, @Direccion, @Sexo, @FechaNacimiento )
		INSERT INTO NOT_NULL.rolXusuario(usuario_id, rol_id)
		VALUES (@Username, 3)
	END
  GO

  --CREAR AFILIADO
  CREATE PROCEDURE NOT_NULL.Afiliado_Add(@Username varchar(50), @Nombre varchar(50),@Apellido varchar(50), @Dni numeric(8,0), @Mail varchar(50),@Telefono varchar(20), @Direccion varchar(50), @CantHijos numeric(2,0),@CantBonos numeric(18,0), @EstadoCivil char(1), @Fecha datetime, @Habilitado bit, @Plan numeric(18,0), @Sexo char(1))
  AS
	BEGIN
	SET NOCOUNT ON;
		INSERT INTO NOT_NULL.afiliado(usuario_id,afiliado_nombre,afiliado_apellido,afiliado_dni,afiliado_mail,afiliado_telefono,afiliado_direccion,afiliado_cant_hijos,afiliado_cant_bonos_consulta, afiliado_estado_civil, afiliado_fecha_nac, afiliado_habilitado, afiliado_plan, afiliado_sexo)
		VALUES (@Username, @Nombre, @Apellido, @Dni, @Mail, @Telefono,@Direccion, @CantHijos, @CantBonos, @EstadoCivil, @Fecha, @Habilitado, @Plan, @Sexo)
		INSERT INTO NOT_NULL.rolXusuario(usuario_id, rol_id)
		VALUES (@Username, 2)
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
  CREATE PROCEDURE NOT_NULL.Afiliado_Modify(@Username varchar(50), @Nombre varchar(50),@Apellido varchar(50), @Dni numeric(8,0), @Mail varchar(50),@Telefono varchar(20), @Direccion varchar(50), @CantHijos numeric(2,0),@CantBonos numeric(18,0), @EstadoCivil char(1), @Fecha datetime, @Habilitado bit, @Plan numeric(18,0), @Sexo char(1))
  AS
	BEGIN
	SET NOCOUNT ON;
		UPDATE NOT_NULL.afiliado
		SET usuario_id = @Username,afiliado_nombre=@Nombre,afiliado_apellido=@Apellido,afiliado_dni=@Dni,afiliado_mail=@Mail,afiliado_telefono=@Telefono,afiliado_direccion=@Direccion,afiliado_cant_hijos=@CantHijos,afiliado_cant_bonos_consulta=@CantBonos, afiliado_estado_civil=@EstadoCivil, afiliado_fecha_nac=@Fecha, afiliado_habilitado=@Habilitado, afiliado_plan=@Plan, afiliado_sexo=@Sexo
		WHERE usuario_id = @Username
	END
  GO


  --CAMBIAR CONTRASEŅA DE USUARIO
  CREATE PROCEDURE NOT_NULL.Usuario_CambiarContraseņa(@Username varchar(20), @Password varchar(20))
  AS
	BEGIN
	SET NOCOUNT ON;
		UPDATE NOT_NULL.Usuario
		SET usuario_password = HASHBYTES('SHA2_256', @Password)
		WHERE usuario_id = @Username
	END
  GO


  --ACTIVAR USUARIO
  CREATE PROCEDURE NOT_NULL.Usuario_Activo(@Username varchar(20), @Activo bit)
  AS
	BEGIN
	SET NOCOUNT ON;
		UPDATE NOT_NULL.Usuario
		SET usuario_habilitado = @Activo
		WHERE usuario_id = @Username
	END
  GO


  --OBTENER TODOS LOS AFILIADOS
  CREATE PROCEDURE NOT_NULL.Afiliado_GetAll
  AS
	BEGIN
	SET NOCOUNT ON;
		SELECT * FROM NOT_NULL.afiliado ORDER BY afiliado_dni
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
  CREATE PROCEDURE NOT_NULL.Afiliado_GetByFilters(@nombre varchar(20), @apellido varchar(20), @mail varchar(50))
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

  --OBTENER AFILIADO SEGUN USUARIO
  CREATE PROCEDURE NOT_NULL.Afiliado_GetAfiliadoSegunUsuario (@username varchar(20))
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
  CREATE PROCEDURE NOT_NULL.Profesional_GetProfesionalSegunUsuario (@username varchar(20))
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
		UPDATE NOT_NULL.rolXusuario
		SET rolXusuario_habilitado = 1 WHERE rol_id = @rol
	END
  GO


  --DESACTIVAR ROL
  CREATE PROCEDURE NOT_NULL.Rol_Deactivate(@rol int)
  AS
	BEGIN
	SET NOCOUNT ON;
		UPDATE NOT_NULL.Rol
		SET rol_habilitado = 0 WHERE rol_id = @rol
		UPDATE NOT_NULL.rolXusuario
		SET rolXusuario_habilitado = 0 WHERE rol_id = @rol
	END
  GO