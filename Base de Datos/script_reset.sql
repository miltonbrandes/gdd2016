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

DROP TABLE NOT_NULL.medicoXespecialidad
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


DROP TABLE NOT_NULL.afiliado
GO

DROP TABLE NOT_NULL.plan_medico
GO

DROP TABLE NOT_NULL.usuario
GO

DROP procedure NOT_NULL.contarBonos
GO

DROP procedure NOT_NULL.Usuario_Get
GO

DROP procedure NOT_NULL.Usuario_ResetearIntentos
GO

DROP procedure NOT_NULL.Usuario_SumarIntento
GO

DROP SCHEMA NOT_NULL
GO