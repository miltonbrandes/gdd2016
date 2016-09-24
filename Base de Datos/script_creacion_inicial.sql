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
	funcion_id int NOT NULL,
	funcion_descripcion varchar(50) NULL,
 CONSTRAINT [PK_funcion] PRIMARY KEY CLUSTERED 
(
	[funcion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/*ROL*/
CREATE TABLE NOT_NULL.rol(
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
CREATE TABLE NOT_NULL.funcionXrol(
	rol_id int NOT NULL,
	funcion_id int NOT NULL,
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
	 afiliado_habilitado numeric(2,0),
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
afiliado_sexo, afiliado_fecha_nac, afiliado_telefono, afiliado_mail, afiliado_direccion, afiliado_cant_hijos, afiliado_cant_bonos_consulta, afiliado_plan)
select Paciente_Nombre, Paciente_Apellido, Paciente_Dni, 'N', 'N', Paciente_Fecha_Nac, Paciente_Telefono, Paciente_Mail, Paciente_Direccion, 0, 0, Plan_Med_Codigo 
	from gd_esquema.Maestra
	group by Paciente_Nombre, Paciente_Apellido, Paciente_Dni, Paciente_Fecha_Nac, Paciente_Telefono, Paciente_Mail, Paciente_Direccion, Plan_Med_Codigo
go

/*		BONOS		*/

create table NOT_NULL.bono_consulta (
	 bono_id numeric(18,0) primary key, 
	 bono_afiliado numeric(18,0) foreign key references NOT_NULL.afiliado(afiliado_nro),
	 bono_plan numeric(18,0) foreign key references NOT_NULL.plan_medico(plan_id),
	 -- bono_turno numeric(18,0) foreign key references turno(turno_id),
	 bono_fecha_compra datetime,
	 bono_utilizado character(1)
)
go

insert into NOT_NULL.bono_consulta (bono_id, bono_afiliado, bono_plan, bono_fecha_compra)
select Bono_Consulta_Numero, afiliado_nro, Plan_Med_Codigo, Compra_Bono_Fecha
	from gd_esquema.Maestra, NOT_NULL.afiliado
	where Bono_Consulta_Numero is not null and Compra_Bono_Fecha is not null and afiliado_dni = Paciente_Dni
	order by Bono_Consulta_Numero, Paciente_Dni, Plan_Med_Codigo, Compra_Bono_Fecha
go

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
	turno_hora time(7) NULL,
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

/*Creacion de agenda*/
CREATE TABLE NOT_NULL.agenda(
	agenda_id int PRIMARY KEY IDENTITY(0,1),
	agenda_profesional int NOT NULL references NOT_NULL.profesional,
	agenda_especialidad numeric(18,0) NOT NULL references NOT_NULL.especialidad)
GO

CREATE TABLE NOT_NULL.franja_horaria(
	franja_id int PRIMARY KEY IDENTITY(0,1),
	agenda int NOT NULL references NOT_NULL.agenda,
	dia int NOT NULL CHECK(dia >=1 AND dia <=7),
	hora_inicio int NOT NULL CHECK(hora_inicio<24 AND hora_inicio>=0),
	minuto_inicio int NOT NULL CHECK(minuto_inicio<60 AND minuto_inicio>=0),
	hora_fin int NOT NULL CHECK(hora_fin<24 AND hora_fin>=0),
	minuto_fin int NOT NULL CHECK(minuto_fin<60 AND minuto_fin>=0)	)
GO

ALTER TABLE NOT_NULL.franja_horaria
	ADD CONSTRAINT hora_fin_mayor_hora_inicio CHECK( (hora_fin * 60 + minuto_fin) > (hora_inicio * 60 + minuto_inicio) )
GO