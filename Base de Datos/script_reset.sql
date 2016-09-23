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