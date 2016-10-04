use GD2C2016
GO

/*Lo hago aca xq turno referencia a medXesp */
DROP TABLE NOT_NULL.bono_consulta
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

DROP TABLE NOT_NULL.franja_horaria
GO

DROP TABLE NOT_NULL.agenda

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

DROP TABLE NOT_NULL.cancelacion_turno
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
drop procedure NOT_NULL.Usuario_CambiarContraseña
drop procedure NOT_NULL.Usuario_Habilitar
drop procedure NOT_NULL.Usuario_Inhabilitar
drop procedure NOT_NULL.RolXFuncion_Active
DROP SCHEMA NOT_NULL
GO