use GD2C2016
GO

--Saco todas las constraints
ALTER TABLE NOT_NULL.bono_consulta NOCHECK CONSTRAINT ALL
GO
ALTER TABLE NOT_NULL.turno NOCHECK CONSTRAINT ALL
GO
ALTER TABLE NOT_NULL.funcionXrol NOCHECK CONSTRAINT ALL
GO
ALTER TABLE NOT_NULL.rolXusuario NOCHECK CONSTRAINT ALL
GO
ALTER TABLE NOT_NULL.funcion NOCHECK CONSTRAINT ALL
GO
ALTER TABLE NOT_NULL.rol NOCHECK CONSTRAINT ALL
GO
ALTER TABLE NOT_NULL.franja_horaria NOCHECK CONSTRAINT ALL
GO
ALTER TABLE NOT_NULL.agenda NOCHECK CONSTRAINT ALL
GO
ALTER TABLE NOT_NULL.medicoXespecialidad NOCHECK CONSTRAINT ALL
GO
ALTER TABLE NOT_NULL.especialidad NOCHECK CONSTRAINT ALL
GO
ALTER TABLE NOT_NULL.tipo_especialidad NOCHECK CONSTRAINT ALL
GO
ALTER TABLE NOT_NULL.modificacion_plan NOCHECK CONSTRAINT ALL
GO
ALTER TABLE NOT_NULL.cancelacion_turno NOCHECK CONSTRAINT ALL
GO
ALTER TABLE NOT_NULL.profesional NOCHECK CONSTRAINT ALL
GO
ALTER TABLE NOT_NULL.compra_bono NOCHECK CONSTRAINT ALL
GO
ALTER TABLE NOT_NULL.afiliado NOCHECK CONSTRAINT ALL
GO
ALTER TABLE NOT_NULL.usuario NOCHECK CONSTRAINT ALL
GO
ALTER TABLE NOT_NULL.plan_medico NOCHECK CONSTRAINT ALL
GO
ALTER TABLE NOT_NULL.modificacion_plan NOCHECK CONSTRAINT ALL
GO
ALTER TABLE NOT_NULL.turno NOCHECK CONSTRAINT ALL
GO

/*Lo hago aca xq turno referencia a medXesp */

DROP TABLE NOT_NULL.franja_horaria
GO

DROP TABLE NOT_NULL.agenda
GO
DROP TABLE NOT_NULL.bono_consulta
GO
DROP TABLE NOT_NULL.cancelacion_turno
GO

DROP TABLE NOT_NULL.turno
GO

/*drop tablas relacion*/
DROP TABLE NOT_NULL.funcionXrol
GO

DROP TABLE NOT_NULL.rolXusuario
GO


/* ***************************************** */


/*Tablas que quedaron colgando de la relacion*/
DROP TABLE NOT_NULL.funcion
GO

DROP TABLE NOT_NULL.rol
GO

DROP TABLE NOT_NULL.medicoXespecialidad
GO

DROP TABLE NOT_NULL.especialidad
GO

DROP TABLE NOT_NULL.tipo_especialidad
GO
/* ***************************************** */

DROP TABLE NOT_NULL.modificacion_plan
GO


DROP TABLE NOT_NULL.profesional
GO

DROP TABLE NOT_NULL.compra_bono
GO

DROP TABLE NOT_NULL.afiliado
GO

DROP TABLE NOT_NULL.usuario
GO

DROP TABLE NOT_NULL.plan_medico
GO

DROP procedure NOT_NULL.asignar_nro_bonos_afiliado
GO

DROP procedure NOT_NULL.Usuario_Get
GO

DROP procedure NOT_NULL.Usuario_ResetearIntentos
GO

DROP procedure NOT_NULL.Usuario_SumarIntento
GO

DROP procedure NOT_NULL.Usuario_GetAll

DROP procedure NOT_NULL.Usuario_LogIn

DROP procedure NOT_NULL.UsuarioXRol_GetRolesByUser
drop procedure NOT_NULL.Afiliado_Obtener_Nro
drop procedure NOT_NULL.Afiliado_Add
drop procedure NOT_NULL.Afiliado_GetAll
drop procedure NOT_NULL.Afiliado_GetAfiliadoSegunUsuario
drop procedure NOT_NULL.Afiliado_GetByDni
drop procedure NOT_NULL.Afiliado_GetByFilters
drop procedure NOT_NULL.Afiliado_Modify
drop procedure NOT_NULL.Bonos_GetBonosSegunAfiliado
drop procedure NOT_NULL.Funciones_GetAll
drop procedure NOT_NULL.Profesional_Add
drop procedure NOT_NULL.Profesional_GetByDni
drop procedure NOT_NULL.Profesional_GetByFilters
drop procedure NOT_NULL.Profesional_GetProfesionalSegunUsuario
drop procedure NOT_NULL.Profesional_Modify
drop procedure NOT_NULL.Profesionales_GetAll
drop procedure NOT_NULL.Rol_Activate
drop procedure NOT_NULL.Rol_Add
drop procedure NOT_NULL.Rol_Deactivate
drop procedure NOT_NULL.Rol_Exists
drop procedure NOT_NULL.Rol_GetAll
drop procedure NOT_NULL.Rol_GetByName
drop procedure NOT_NULL.Rol_ModifyName
drop procedure NOT_NULL.RolXFuncion_Add
drop procedure NOT_NULL.RolXFuncion_GetFunByRol
drop procedure NOT_NULL.RolXFuncion_Remove
drop procedure NOT_NULL.Usuario_Activo
drop procedure NOT_NULL.Usuario_Add
drop procedure NOT_NULL.Usuario_CambiarContrasenia
drop procedure NOT_NULL.Usuario_Habilitar
drop procedure NOT_NULL.Usuario_Inhabilitar
drop procedure NOT_NULL.RolXFuncion_Active
drop procedure NOT_NULL.Planes_GetAll
drop procedure NOT_NULL.Agregar_Modif_Plan
drop procedure NOT_NULL.Planes_GetPlanAfiliado
drop procedure NOT_NULL.Planes_GetPorId
drop procedure NOT_NULL.Usuario_Exists
drop procedure NOT_NULL.Modif_Plan_Get_All
drop procedure NOT_NULL.Afiliado_Baja_Logica
drop procedure NOT_NULL.RolXUsuario_Activate
drop procedure NOT_NULL.UsuarioXRol_GetRolesInhabxUser
drop procedure NOT_NULL.Afiliado_Agregar_Familiar
drop procedure NOT_NULL.Hijos_En_Cero
drop procedure NOT_NULL.Especialidad_GetByMatricula
drop procedure NOT_NULL.Afiliado_MismoDni
drop procedure NOT_NULL.Get_MedicoXEsp_All
drop procedure NOT_NULL.Get_Especialidades_All
drop procedure NOT_NULL.Get_Especialidades_All_2
drop procedure NOT_NULL.Get_Turnos_Today
drop procedure NOT_NULL.Agenda_Agregar
drop procedure NOT_NULL.Turno_Agregar
drop procedure NOT_NULL.Get_medxesp_id
drop procedure NOT_NULL.Franja_Agregar
drop procedure NOT_NULL.turnos_GetByFilerProfesional
drop procedure NOT_NULL.profesional_GetByFilerEspecialidad
drop procedure NOT_NULL.Comprar_Bono
drop PROCEDURE NOT_NULL.listado_Mas_Cancelaciones_Especialidad 
drop PROCEDURE NOT_NULL.listado_Profesionales_Consultados
drop PROCEDURE NOT_NULL.listado_Profesionales_Menos_Horas 
drop PROCEDURE NOT_NULL.listado_Afiliado_Mas_Bonos
drop PROCEDURE NOT_NULL.listado_Especialidad_Mas_Bonos
drop procedure NOT_NULL.Afiliado_GetAfiliadoSegunNro
drop procedure NOT_NULL.Get_Especialidades_Sin_Agenda
drop procedure NOT_NULL.GetTurnosDiaLlegaron
drop procedure NOT_NULL.Registrar_Resultado
drop procedure NOT_NULL.Get_Turnos_Prof_Reservados
drop procedure NOT_NULL.especialidades_GetByFilerEspecialidad
drop procedure NOT_NULL.Get_Bonos_Afiliado
drop procedure NOT_NULL.Registrar_Llegada
drop procedure NOT_NULL.Cancelar_Turno_Afiliado
drop procedure NOT_NULL.Turnos_Afiliado
drop procedure NOT_NULL.Get_Dias_Turno_Prof
drop procedure NOT_NULL.Get_Franjas_Profesional
drop procedure NOT_NULL.Cancelar_Turnos_Profesional
drop procedure NOT_NULL.Cancelar_Turnos_ProfxFranja 
drop procedure NOT_NULL.Cancelar_Turnos_Varios_Dias 
drop procedure NOT_NULL.reservarTurno_GetByFilerProfesional
DROP SCHEMA NOT_NULL
GO