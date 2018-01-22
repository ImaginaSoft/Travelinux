﻿using TraveLinux.Data.Entidades;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;
namespace TraveLinux.Data
{
    public class AccesoDatos
    {
        private string _connectionString;

        public AccesoDatos(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public void GuardarCliente(Cliente eCliente)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                var command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = string.Concat(Globales_DAL.gs_PACKAGENAME, "SP_CREAR_CLIENTE");
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("P_NOMBRE", OracleDbType.Varchar2, 50).Value = eCliente.NOMBRE;
                command.Parameters.Add("P_PATERNO", OracleDbType.Varchar2, 50).Value = eCliente.PATERNO;
                command.Parameters.Add("P_MATERNO", OracleDbType.Varchar2, 50).Value = eCliente.MATERNO;
                command.Parameters.Add("P_DOCUMENTO", OracleDbType.Char, 5).Value = eCliente.DOCUMENTO;
                command.Parameters.Add("P_NUMERO", OracleDbType.Varchar2, 50).Value = eCliente.NUMERO;
                command.Parameters.Add("P_FEC_NACIMIENTO", OracleDbType.Date).Value = Convert.ToDateTime(eCliente.FEC_NACIMIENTO);
                command.Parameters.Add("P_RANGO_EDAD", OracleDbType.Varchar2, 50).Value = eCliente.RANGO_EDAD;
                command.Parameters.Add("P_ESTADO_CIVIL", OracleDbType.Varchar2, 50).Value = eCliente.ESTADO_CIVIL;
                command.Parameters.Add("P_GENERO", OracleDbType.Varchar2, 50).Value = eCliente.GENERO;
                command.Parameters.Add("P_PAIS", OracleDbType.Varchar2, 50).Value = eCliente.PAIS;
                command.Parameters.Add("P_DEPARTAMENTO", OracleDbType.Varchar2, 50).Value = eCliente.DEPARTAMENTO;                
                command.Parameters.Add("P_DIRECCION", OracleDbType.Varchar2, 50).Value = eCliente.DIRECCION;
                command.Parameters.Add("P_IDIOMA", OracleDbType.Varchar2, 50).Value = eCliente.IDIOMA;
                command.Parameters.Add("P_EMAIL", OracleDbType.Varchar2, 50).Value = eCliente.EMAIL;
                command.Parameters.Add("P_EMAIL_2", OracleDbType.Varchar2, 50).Value = eCliente.EMAIL_2;
                command.Parameters.Add("P_EMAIL_3", OracleDbType.Varchar2, 50).Value = eCliente.EMAIL_3;
                command.Parameters.Add("P_TELEFONO", OracleDbType.Varchar2, 50).Value = eCliente.TELEFONO;
                command.Parameters.Add("P_TELEFONO_2", OracleDbType.Varchar2, 50).Value = eCliente.TELEFONO_2;
                command.Parameters.Add("P_TELEFONO_3", OracleDbType.Varchar2, 50).Value = eCliente.TELEFONO_3;
                command.Parameters.Add("P_NOTAS", OracleDbType.Varchar2, 50).Value = eCliente.NOTAS;
                command.Parameters.Add("P_ESTADO", OracleDbType.Varchar2, 50).Value = eCliente.ESTADO;
                command.Parameters.Add("P_USUARIO_REGISTRO", OracleDbType.Varchar2, 50).Value = "Jorge";

                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public void ActualizarCliente(Cliente eCliente)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                var command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = string.Concat(Globales_DAL.gs_PACKAGENAME, "SP_ACTUALIZAR_CLIENTE");
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("P_CLIENTE", OracleDbType.Varchar2, 50).Value = eCliente.CLIENTE;
                command.Parameters.Add("P_NOMBRE", OracleDbType.Varchar2, 50).Value = eCliente.NOMBRE;
                command.Parameters.Add("P_PATERNO", OracleDbType.Varchar2, 50).Value = eCliente.PATERNO;
                command.Parameters.Add("P_MATERNO", OracleDbType.Varchar2, 50).Value = eCliente.MATERNO;
                command.Parameters.Add("P_DOCUMENTO", OracleDbType.Char, 5).Value = eCliente.DOCUMENTO;
                command.Parameters.Add("P_NUMERO", OracleDbType.Varchar2, 50).Value = eCliente.NUMERO;
                command.Parameters.Add("P_FEC_NACIMIENTO", OracleDbType.Date).Value = Convert.ToDateTime(eCliente.FEC_NACIMIENTO);
                command.Parameters.Add("P_RANGO_EDAD", OracleDbType.Varchar2, 50).Value = eCliente.RANGO_EDAD;
                command.Parameters.Add("P_ESTADO_CIVIL", OracleDbType.Varchar2, 50).Value = eCliente.ESTADO_CIVIL;
                command.Parameters.Add("P_GENERO", OracleDbType.Varchar2, 50).Value = eCliente.GENERO;
                command.Parameters.Add("P_PAIS", OracleDbType.Varchar2, 50).Value = eCliente.PAIS;
                command.Parameters.Add("P_DEPARTAMENTO", OracleDbType.Varchar2, 50).Value = eCliente.DEPARTAMENTO;
                command.Parameters.Add("P_DIRECCION", OracleDbType.Varchar2, 50).Value = eCliente.DIRECCION;
                command.Parameters.Add("P_IDIOMA", OracleDbType.Varchar2, 50).Value = eCliente.IDIOMA;
                command.Parameters.Add("P_EMAIL_1", OracleDbType.Varchar2, 50).Value = eCliente.EMAIL;
                command.Parameters.Add("P_EMAIL_2", OracleDbType.Varchar2, 50).Value = eCliente.EMAIL_2;
                command.Parameters.Add("P_EMAIL_3", OracleDbType.Varchar2, 50).Value = eCliente.EMAIL_3;
                command.Parameters.Add("P_TELEFONO_1", OracleDbType.Varchar2, 50).Value = eCliente.TELEFONO;
                command.Parameters.Add("P_TELEFONO_2", OracleDbType.Varchar2, 50).Value = eCliente.TELEFONO_2;
                command.Parameters.Add("P_TELEFONO_3", OracleDbType.Varchar2, 50).Value = eCliente.TELEFONO_3;
                command.Parameters.Add("P_NOTAS", OracleDbType.Varchar2, 50).Value = eCliente.NOTAS;
                command.Parameters.Add("P_ESTADO", OracleDbType.Varchar2, 50).Value = eCliente.ESTADO;
                command.Parameters.Add("P_USUARIO_ULT_MODIF", OracleDbType.Varchar2, 50).Value = "Jorge";

                connection.Open();
                command.ExecuteNonQuery();
            }

        }
        public IEnumerable<TipoDocumento> ObtenerTipoDocumento()
        {
            var tdocumentos = new List<TipoDocumento>();

            using (var connection = new OracleConnection(_connectionString))
            {
                var command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = string.Concat(Globales_DAL.gs_PACKAGENAME, "SP_LISTAR_TIPODOCUMENTO");
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("P_RECORDSET", OracleDbType.RefCursor, ParameterDirection.Output);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tipoDocumento = new TipoDocumento();
                        tipoDocumento.DOCUMENTO = reader["DOCUMENTO"].ToString();
                        tipoDocumento.DESCRIPCION = reader["DESCRIPCION"].ToString();
                        tdocumentos.Add(tipoDocumento);
                    }
                }
            }

            return tdocumentos;
        }

        public IEnumerable<Moneda> ObtenerMonedas()
        {
            var monedas = new List<Moneda>();

            using (var connection = new OracleConnection(_connectionString))
            {
                var command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = string.Concat(Globales_DAL.gs_PACKAGENAME, "SP_LISTAR_MONEDA");
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("P_RECORDSET", OracleDbType.RefCursor, ParameterDirection.Output);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var moneda = new Moneda();
                        moneda.MONEDA = reader.GetStringOrDefault(0);
                        moneda.DESCRIPCION = reader.GetStringOrDefault(1);
                        moneda.VALOR = reader.GetDecimal(2);
                        moneda.ESTADO = reader.GetInt32(3);
                        monedas.Add(moneda);
                    }
                }
            }

            return monedas;
        }

        public IEnumerable<Cliente> ObtenerListaCliente()
        {
            var lclientes = new List<Cliente>();

            using (var connection = new OracleConnection(_connectionString))
            {
                var command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = string.Concat(Globales_DAL.gs_PACKAGENAME, "SP_LISTAR_CLIENTE");
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("P_RECORDSET", OracleDbType.RefCursor, ParameterDirection.Output);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var cliente = new Cliente();
                        cliente.CLIENTE = reader.GetStringOrDefault(0);
                        cliente.NOMBRE = reader.GetStringOrDefault(1);
                        cliente.PATERNO = reader.GetStringOrDefault(2);
                        cliente.MATERNO = reader.GetStringOrDefault(3);
                        cliente.DOCUMENTO = reader.GetStringOrDefault(4);
                        cliente.NUMERO = reader.GetStringOrDefault(5);
                        cliente.FEC_NACIMIENTO = reader.GetDateTimeOrDefault(6);
                        cliente.RANGO_EDAD = reader.GetStringOrDefault(7);
                        cliente.ESTADO_CIVIL = reader.GetStringOrDefault(8);
                        cliente.GENERO = reader.GetStringOrDefault(9);
                        cliente.PAIS = reader.GetStringOrDefault(10);
                        cliente.DEPARTAMENTO = reader.GetStringOrDefault(11);                        
                        cliente.DIRECCION = reader.GetStringOrDefault(12);
                        cliente.IDIOMA = reader.GetStringOrDefault(13);
                        cliente.EMAIL = reader.GetStringOrDefault(14);
                        cliente.EMAIL_2 = reader.GetStringOrDefault(15);
                        cliente.EMAIL_3 = reader.GetStringOrDefault(16);
                        cliente.TELEFONO = reader.GetStringOrDefault(17);
                        cliente.TELEFONO_2 = reader.GetStringOrDefault(18);
                        cliente.TELEFONO_3 = reader.GetStringOrDefault(19);
                        cliente.NOTAS= reader.GetStringOrDefault(20);
                        cliente.ESTADO = reader.GetStringOrDefault(21);
                        cliente.FECHA_REGISTRO = reader.GetDateTimeOrDefault(22);
                        cliente.USUARIO_REGISTRO = reader.GetStringOrDefault(23);
                        cliente.FECHA_ULT_MODIF = reader.GetDateTimeOrDefault(24);
                        cliente.USUARIO_ULT_MODIF = reader.GetStringOrDefault(25);
                        lclientes.Add(cliente);
                    }
                }
            }

            return lclientes;
        }

        public void GuardarTarifaDetalle(List<Tarifa_Detalle> lsttarifa)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Proveedor> ObtenerListaProveedor()
        {
            var lproveedor = new List<Proveedor>();

            using (var connection = new OracleConnection(_connectionString))
            {
                var command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = string.Concat(Globales_DAL.gs_PACKAGENAME, "SP_LISTAR_PROVEEDOR");
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("P_RECORDSET", OracleDbType.RefCursor, ParameterDirection.Output);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var proveedor = new Proveedor();
                        proveedor.PROVEEDOR = reader.GetStringOrDefault(0);
                        proveedor.NOMBRE = reader.GetStringOrDefault(1);
                        proveedor.ALIAS = reader.GetStringOrDefault(2);
                        proveedor.TPROVEEDOR = reader.GetStringOrDefault(3);
                        proveedor.TIPO = reader.GetStringOrDefault(4);
                        proveedor.PAIS = reader.GetStringOrDefault(5);
                        proveedor.CIUDAD = reader.GetStringOrDefault(6);
                        proveedor.DIRECCION = reader.GetStringOrDefault(7);
                        proveedor.PAGINAWEB = reader.GetStringOrDefault(8);
                        proveedor.RUC = reader.GetStringOrDefault(9);
                        proveedor.IDIOMA = reader.GetStringOrDefault(10);
                        proveedor.ESTADO = reader.GetStringOrDefault(11);
                        //proveedor.USUARIO_REGISTRO = reader.GetStringOrDefault(12);

                        lproveedor.Add(proveedor);
                    }
                }
            }

            return lproveedor;
        }

        public IEnumerable<Tarifa_Detalle> ObtenerTarifaDetalle(string Proveedor, string Tarifa)
        {
            var lproveedor = new List<Tarifa_Detalle>();

            using (var connection = new OracleConnection(_connectionString))
            {
                var command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = string.Concat(Globales_DAL.gs_PACKAGENAME, "SP_LISTAR_TARIFDET");
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("P_PROVEEDOR", OracleDbType.Varchar2, 50).Value = Proveedor;
                command.Parameters.Add("P_TARIFA", OracleDbType.Varchar2, 50).Value = Tarifa;
                command.Parameters.Add("P_RECORDSET", OracleDbType.RefCursor, ParameterDirection.Output);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var detalle = new Tarifa_Detalle();
                        detalle.PROVEEDOR = reader.GetStringOrDefault(0);
                        detalle.PROVEEDOR_NOMBRE = reader.GetStringOrDefault(1);
                        detalle.TARIFA = reader.GetStringOrDefault(2);
                        detalle.TARIFA_NOMBRE = reader.GetStringOrDefault(3);

                        lproveedor.Add(detalle);
                    }
                }
            }

            return lproveedor;
        }

        public IEnumerable<Tarifa> ObtenerListaTarifa(string Proveedor)
        {
            var lstTarifa = new List<Tarifa>();

            using (var connection = new OracleConnection(_connectionString))
            {
                var command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = string.Concat(Globales_DAL.gs_PACKAGENAME, "SP_LISTAR_TARIFA");
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("P_PROVEEDOR", OracleDbType.Varchar2, 50).Value = Proveedor;
                command.Parameters.Add("P_RECORDSET", OracleDbType.RefCursor, ParameterDirection.Output);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tarifa = new Tarifa();
                        tarifa.TARIFA = reader.GetStringOrDefault(0);
                        tarifa.PROVEEDOR = reader.GetStringOrDefault(1);
                        tarifa.PROVEEDOR_NOMBRE = reader.GetStringOrDefault(2);
                        tarifa.NOMBRE = reader.GetStringOrDefault(3);
                        tarifa.FECHA_COMENZAR = reader.GetDateTimeOrDefault(4);
                        tarifa.FECHA_INICIO = reader.GetDateTimeOrDefault(5);
                        tarifa.FECHA_FINAL = reader.GetDateTimeOrDefault(6);
                        tarifa.NOTAS = reader.GetStringOrDefault(7);
                        tarifa.ESTADO = reader.GetStringOrDefault(8);
                        tarifa.DINAMICO = reader.GetInt32 (9);
                        tarifa.FECHA_REGISTRO = reader.GetDateTimeOrDefault(10);
                        tarifa.USUARIO_REGISTRO = reader.GetStringOrDefault(11);
                        tarifa.FECHA_ULT_MODIF = reader.GetDateTimeOrDefault(12);
                        tarifa.USUARIO_ULT_MODIF = reader.GetStringOrDefault(13);
                        lstTarifa.Add(tarifa);
                    }
                }
            }

            return lstTarifa;
        }

        public IEnumerable<Servicio> ListadoServicioxProveedor(string Proveedor)
        {
            var lstservicio = new List<Servicio>();

            using (var connection = new OracleConnection(_connectionString))
            {
                var command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = string.Concat(Globales_DAL.gs_PACKAGENAME, "SP_LISTAR_SERVXPROV");
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("P_PROVEEDOR", OracleDbType.Varchar2, 9).Value = Proveedor;
                command.Parameters.Add("P_RECORDSET", OracleDbType.RefCursor, ParameterDirection.Output);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var servicio = new Servicio();
                        servicio.PROVEEDOR = reader.GetStringOrDefault(0);
                        servicio.PROVEEDOR_NOMBRE = reader.GetStringOrDefault(1);                        
                        servicio.SERVICIO = reader.GetStringOrDefault(2);
                        servicio.NOMBRE = reader.GetStringOrDefault(3);
                        servicio.TIPO = reader.GetStringOrDefault(4);
                        servicio.VALORXSERVICIO = reader.GetStringOrDefault(5);
                        servicio.VALOR = reader.GetStringOrDefault(6);
                        servicio.DURACION = reader.GetStringOrDefault(7);
                        servicio.TURNO = reader.GetStringOrDefault(8);
                        servicio.DESAYUNO = reader.GetStringOrDefault(9);
                        servicio.ALMUERZO = reader.GetStringOrDefault(10);
                        servicio.CENA = reader.GetStringOrDefault(11);
                        servicio.AEROLINEA = reader.GetStringOrDefault(12);
                        servicio.BOX_LUNCH = reader.GetStringOrDefault(13);
                        servicio.RUTA = reader.GetStringOrDefault(14);
                        servicio.DESCRIPCION = reader.GetStringOrDefault(15);
                        servicio.TIPO_SERVICIO = reader.GetStringOrDefault(16);
                        servicio.TIPO_PERSONA = reader.GetStringOrDefault(17);
                        servicio.DESC_ESP = reader.GetStringOrDefault(18);
                        servicio.DESC_INGL = reader.GetStringOrDefault(19);
                        servicio.DESC_PORT = reader.GetStringOrDefault(20);
                        servicio.DESC_ALE = reader.GetStringOrDefault(21);
                        servicio.ESTADO = reader.GetStringOrDefault(22);
                        lstservicio.Add(servicio);
                    }
                }
            }

            return lstservicio;
        }

        public void GuardarMoneda(Moneda eMoneda)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                var command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = string.Concat(Globales_DAL.gs_PACKAGENAME, "SP_CREAR_MONEDA");
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("P_DESCRIPCION", OracleDbType.Varchar2, 50).Value = eMoneda.DESCRIPCION;
                command.Parameters.Add("P_VALOR", OracleDbType.Decimal).Value = eMoneda.VALOR;
                command.Parameters.Add("P_ESTADO", OracleDbType.Int32).Value = eMoneda.ESTADO;

                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public IEnumerable<Pais> ObtenerPaises()
        {
            var lpaises = new List<Pais>();

            using (var connection = new OracleConnection(_connectionString))
            {
                var command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = string.Concat(Globales_DAL.gs_PACKAGENAME, "SP_LISTAR_PAIS");
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("P_RECORDSET", OracleDbType.RefCursor, ParameterDirection.Output);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var pais = new Pais();
                        pais.PAIS = reader.GetStringOrDefault(0);
                        pais.NOMBRE = reader.GetStringOrDefault(1);

                        lpaises.Add(pais);
                    }
                }
            }

            return lpaises;
        }

        public IEnumerable<Temporada> ObtenerTemporadas()
        {
            var lsttemporada = new List<Temporada>();

            using (var connection = new OracleConnection(_connectionString))
            {
                var command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = string.Concat(Globales_DAL.gs_PACKAGENAME, "SP_LISTAR_TEMPORADA");
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("P_RECORDSET", OracleDbType.RefCursor, ParameterDirection.Output);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var temporada = new Temporada();
                        temporada.Temporadas = reader.GetStringOrDefault(0);
                        temporada.Descripcion = reader.GetStringOrDefault(1);

                        lsttemporada.Add(temporada);
                    }
                }
            }

            return lsttemporada;
        }


        public List<Departamentos> ListadoDepartamento(string sPais)
        {
            var ldepartamentos = new List<Departamentos>();

            using (var connection = new OracleConnection(_connectionString))
            {
                var command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = string.Concat(Globales_DAL.gs_PACKAGENAME, "SP_LISTAR_DEPTXPAIS");
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("P_PAIS", OracleDbType.Varchar2, 50).Value = sPais;
                command.Parameters.Add("P_RECORDSET", OracleDbType.RefCursor, ParameterDirection.Output);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var departamento = new Departamentos();
                        departamento.DEPARTAMENTO = reader.GetStringOrDefault(0);
                        departamento.NOMBRE = reader.GetStringOrDefault(1);

                        ldepartamentos.Add(departamento);
                    }
                }
            }

            return ldepartamentos;
        }

        public void GuardarProveedor(Proveedor eProveedor)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                var command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = string.Concat(Globales_DAL.gs_PACKAGENAME, "SP_CREAR_PROVEEDOR");
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("P_NOMBRE", OracleDbType.Varchar2, 50).Value = eProveedor.NOMBRE;
                command.Parameters.Add("P_ALIAS", OracleDbType.Varchar2, 50).Value = eProveedor.ALIAS;
                command.Parameters.Add("P_TPROVEEDOR", OracleDbType.Varchar2, 50).Value = eProveedor.TPROVEEDOR;
                command.Parameters.Add("P_TIPO", OracleDbType.Varchar2, 50).Value = eProveedor.TIPO;
                command.Parameters.Add("P_PAIS", OracleDbType.Varchar2, 50).Value = eProveedor.PAIS;
                command.Parameters.Add("P_CIUDAD", OracleDbType.Varchar2, 50).Value = eProveedor.CIUDAD;
                command.Parameters.Add("P_DIRECCION", OracleDbType.Varchar2, 50).Value = eProveedor.DIRECCION;
                command.Parameters.Add("P_IDIOMA", OracleDbType.Varchar2, 50).Value = eProveedor.IDIOMA;
                command.Parameters.Add("P_PAGINAWEB", OracleDbType.Varchar2, 50).Value = eProveedor.PAGINAWEB;
                command.Parameters.Add("P_RUC", OracleDbType.Varchar2, 50).Value = eProveedor.RUC;
                command.Parameters.Add("P_EMAIL_1", OracleDbType.Varchar2, 50).Value = eProveedor.EMAIL_1;
                command.Parameters.Add("P_EMAIL_2", OracleDbType.Varchar2, 50).Value = eProveedor.EMAIL_2;
                command.Parameters.Add("P_EMAIL_3", OracleDbType.Varchar2, 50).Value = eProveedor.EMAIL_3;
                command.Parameters.Add("P_TELEFONO_1", OracleDbType.Varchar2, 50).Value = eProveedor.TELEFONO_1;
                command.Parameters.Add("P_TELEFONO_2", OracleDbType.Varchar2, 50).Value = eProveedor.TELEFONO_2;
                command.Parameters.Add("P_TELEFONO_3", OracleDbType.Varchar2, 50).Value = eProveedor.TELEFONO_3;
                command.Parameters.Add("P_ESTADO", OracleDbType.Varchar2, 50).Value = eProveedor.ESTADO;
                command.Parameters.Add("P_USUARIO_REGISTRO", OracleDbType.Varchar2, 50).Value = eProveedor.USUARIO_REGISTRO;

                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public void ActualizarProveedor(Proveedor eProveedor)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                var command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = string.Concat(Globales_DAL.gs_PACKAGENAME, "SP_ACTUALIZAR_PROVEEDOR");
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("P_PROVEEDOR", OracleDbType.Varchar2, 50).Value = eProveedor.PROVEEDOR;
                command.Parameters.Add("P_NOMBRE", OracleDbType.Varchar2, 50).Value = eProveedor.NOMBRE;
                command.Parameters.Add("P_ALIAS", OracleDbType.Varchar2, 50).Value = eProveedor.ALIAS;
                command.Parameters.Add("P_TPROVEEDOR", OracleDbType.Varchar2, 50).Value = eProveedor.TPROVEEDOR;
                command.Parameters.Add("P_TIPO", OracleDbType.Varchar2, 50).Value = eProveedor.TIPO;
                command.Parameters.Add("P_PAIS", OracleDbType.Varchar2, 50).Value = eProveedor.PAIS;
                command.Parameters.Add("P_CIUDAD", OracleDbType.Varchar2, 50).Value = eProveedor.CIUDAD;
                command.Parameters.Add("P_DIRECCION", OracleDbType.Varchar2, 50).Value = eProveedor.DIRECCION;
                command.Parameters.Add("P_IDIOMA", OracleDbType.Varchar2, 50).Value = eProveedor.IDIOMA;
                command.Parameters.Add("P_PAGINAWEB", OracleDbType.Varchar2, 50).Value = eProveedor.PAGINAWEB;
                command.Parameters.Add("P_RUC", OracleDbType.Varchar2, 50).Value = eProveedor.RUC;
                command.Parameters.Add("P_EMAIL_1", OracleDbType.Varchar2, 50).Value = eProveedor.EMAIL_1;
                command.Parameters.Add("P_EMAIL_2", OracleDbType.Varchar2, 50).Value = eProveedor.EMAIL_2;
                command.Parameters.Add("P_EMAIL_3", OracleDbType.Varchar2, 50).Value = eProveedor.EMAIL_3;
                command.Parameters.Add("P_TELEFONO_1", OracleDbType.Varchar2, 50).Value = eProveedor.TELEFONO_1;
                command.Parameters.Add("P_TELEFONO_2", OracleDbType.Varchar2, 50).Value = eProveedor.TELEFONO_2;
                command.Parameters.Add("P_TELEFONO_3", OracleDbType.Varchar2, 50).Value = eProveedor.TELEFONO_3;
                command.Parameters.Add("P_ESTADO", OracleDbType.Varchar2, 50).Value = eProveedor.ESTADO;
                command.Parameters.Add("P_USUARIO_ULT_MODIF", OracleDbType.Varchar2, 50).Value = eProveedor.USUARIO_REGISTRO;

                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public void GuardarServicio(Servicio eServicio)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                var command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = string.Concat(Globales_DAL.gs_PACKAGENAME, "SP_CREAR_SERVICIO");
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("P_PROVEEDOR", OracleDbType.Char, 9).Value = eServicio.PROVEEDOR;
                command.Parameters.Add("P_NOMBRE", OracleDbType.Varchar2, 50).Value = eServicio.NOMBRE;
                command.Parameters.Add("P_TIPO", OracleDbType.Varchar2, 50).Value = eServicio.TIPO;
                command.Parameters.Add("P_VALORXSERVICIO", OracleDbType.Varchar2, 50).Value = eServicio.VALORXSERVICIO;
                command.Parameters.Add("P_VALOR", OracleDbType.Varchar2, 50).Value = eServicio.VALOR;
                command.Parameters.Add("P_DURACION", OracleDbType.Varchar2, 50).Value = eServicio.DURACION;
                command.Parameters.Add("P_TURNO", OracleDbType.Varchar2, 50).Value = eServicio.TURNO;
                command.Parameters.Add("P_DESAYUNO", OracleDbType.Varchar2, 50).Value = eServicio.DESAYUNO;
                command.Parameters.Add("P_ALMUERZO", OracleDbType.Varchar2, 50).Value = eServicio.ALMUERZO;
                command.Parameters.Add("P_CENA", OracleDbType.Varchar2, 50).Value = eServicio.CENA;
                command.Parameters.Add("P_AEROLINEA", OracleDbType.Varchar2, 50).Value = eServicio.AEROLINEA;
                command.Parameters.Add("P_BOX_LUNCH", OracleDbType.Varchar2, 50).Value = eServicio.BOX_LUNCH;
                command.Parameters.Add("P_RUTA", OracleDbType.Varchar2, 50).Value = eServicio.RUTA;
                command.Parameters.Add("P_DESCRIPCION", OracleDbType.Varchar2, 50).Value = eServicio.DESCRIPCION;
                command.Parameters.Add("P_TIPO_SERVICIO", OracleDbType.Varchar2, 50).Value = eServicio.TIPO_SERVICIO;
                command.Parameters.Add("P_TIPO_PERSONA", OracleDbType.Varchar2, 50).Value = eServicio.TIPO_PERSONA;
                command.Parameters.Add("P_DESC_ESP", OracleDbType.Varchar2, 50).Value = eServicio.DESC_ESP;
                command.Parameters.Add("P_DESC_INGL", OracleDbType.Varchar2, 50).Value = eServicio.DESC_INGL;
                command.Parameters.Add("P_DESC_PORT", OracleDbType.Varchar2, 50).Value = eServicio.DESC_PORT;
                command.Parameters.Add("P_DESC_ALE", OracleDbType.Varchar2, 50).Value = eServicio.DESC_ALE;
                command.Parameters.Add("P_ESTADO", OracleDbType.Varchar2, 50).Value = eServicio.ESTADO;
                command.Parameters.Add("P_USUARIO_REGISTRO", OracleDbType.Varchar2, 50).Value = eServicio.USUARIO_REGISTRO;

                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public void GuardarTarifa(Tarifa eTarifa)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                var command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = string.Concat(Globales_DAL.gs_PACKAGENAME, "SP_CREAR_TARIFA");
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("P_PROVEEDOR", OracleDbType.Varchar2, 9).Value = eTarifa.PROVEEDOR;
                command.Parameters.Add("P_NOMBRE", OracleDbType.Varchar2, 60).Value = eTarifa.NOMBRE;
                command.Parameters.Add("P_FECHA_VALIDEZ", OracleDbType.Date).Value = Convert.ToDateTime(eTarifa.FECHA_COMENZAR);
                command.Parameters.Add("P_TEMPORADA", OracleDbType.Varchar2, 60).Value = eTarifa.TEMPORADA;
                command.Parameters.Add("P_FECHA_INICIO", OracleDbType.Date).Value = Convert.ToDateTime(eTarifa.FECHA_INICIO);
                command.Parameters.Add("P_FECHA_FINAL", OracleDbType.Date).Value = Convert.ToDateTime(eTarifa.FECHA_FINAL);
                command.Parameters.Add("P_NOTAS", OracleDbType.Varchar2, 50).Value = eTarifa.NOTAS;
                command.Parameters.Add("P_ESTADO", OracleDbType.Varchar2, 50).Value = eTarifa.ESTADO;
                command.Parameters.Add("P_USUARIO_REGISTRO", OracleDbType.Varchar2, 50).Value = eTarifa.USUARIO_REGISTRO;

                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public IEnumerable<Proveedor> ObtenerProveedor(string sProveedor)
        {
            var lstProveedor = new List<Proveedor>();

            using (var connection = new OracleConnection(_connectionString))
            {
                var command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = string.Concat(Globales_DAL.gs_PACKAGENAME, "SP_LISTAR_PROV_TARIFA");
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("P_PROVEEDOR", OracleDbType.Varchar2, 100, sProveedor, ParameterDirection.Input);
                command.Parameters.Add("P_RECORDSET", OracleDbType.RefCursor, ParameterDirection.Output);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var proveedor = new Proveedor();
                        proveedor.PROVEEDOR = reader.GetStringOrDefault(0);
                        proveedor.NOMBRE = reader.GetStringOrDefault(1);
                        proveedor.ALIAS = reader.GetStringOrDefault(2);
                        proveedor.TPROVEEDOR = reader.GetStringOrDefault(3);
                        proveedor.TIPO = reader.GetStringOrDefault(4);
                        proveedor.PAIS = reader.GetStringOrDefault(5);
                        proveedor.CIUDAD = reader.GetStringOrDefault(6);
                        proveedor.DIRECCION = reader.GetStringOrDefault(7);
                        proveedor.PAGINAWEB = reader.GetStringOrDefault(8);
                        proveedor.RUC = reader.GetStringOrDefault(9);
                        proveedor.IDIOMA = reader.GetStringOrDefault(10);
                        proveedor.ESTADO = reader.GetStringOrDefault(11);
                        lstProveedor.Add(proveedor);
                    }
                }
            }

            return lstProveedor;
        }


        public Proveedor ObtenerEditarProveedor(string sProveedor)
        {
            var ObjProveedor = new Proveedor();

            using (var connection = new OracleConnection(_connectionString))
            {
                var command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = string.Concat(Globales_DAL.gs_PACKAGENAME, "SP_OBTENER_LISTA_PROV");
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("P_PROVEEDOR", OracleDbType.Char, 9, sProveedor, ParameterDirection.Input);                
                command.Parameters.Add("P_PROVCODIGO", OracleDbType.Varchar2, 9).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_NOMBRE", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_ALIAS", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_TPROVEEDOR", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_TIPO", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_PAIS", OracleDbType.Varchar2, 5).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_PAISNOM", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_CIUDAD", OracleDbType.Varchar2, 20).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_DIRECCION", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_IDIOMA", OracleDbType.Varchar2, 20).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_PAGINA_WEB", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_RUC", OracleDbType.Varchar2, 20).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_EMAIL_1", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_EMAIL_2", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_EMAIL_3", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_TELEFONO_1", OracleDbType.Varchar2, 20).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_TELEFONO_2", OracleDbType.Varchar2, 20).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_TELEFONO_3", OracleDbType.Varchar2, 20).Direction = ParameterDirection.Output;

                command.Parameters.Add("P_ESTADO", OracleDbType.Char, 1).Direction = ParameterDirection.Output; 
                connection.Open();
                command.ExecuteNonQuery();

               //if (ok == 1)
               // {
                    ObjProveedor.PROVEEDOR = command.Parameters.GetStringOrDefault("P_PROVCODIGO");
                    ObjProveedor.NOMBRE = command.Parameters.GetStringOrDefault("P_NOMBRE");
                    ObjProveedor.ALIAS = command.Parameters.GetStringOrDefault("P_ALIAS");
                    ObjProveedor.TPROVEEDOR = command.Parameters.GetStringOrDefault("P_TPROVEEDOR");
                    ObjProveedor.TIPO = command.Parameters.GetStringOrDefault("P_TIPO");
                    ObjProveedor.PAIS = command.Parameters.GetStringOrDefault("P_PAIS");
                    ObjProveedor.NOMBRE_PAIS = command.Parameters.GetStringOrDefault("P_PAISNOM");
                    ObjProveedor.CIUDAD = command.Parameters.GetStringOrDefault("P_CIUDAD");
                    ObjProveedor.DIRECCION = command.Parameters.GetStringOrDefault("P_DIRECCION");
                    ObjProveedor.IDIOMA = command.Parameters.GetStringOrDefault("P_IDIOMA");
                    ObjProveedor.PAGINAWEB = command.Parameters.GetStringOrDefault("P_PAGINA_WEB");
                    ObjProveedor.RUC = command.Parameters.GetStringOrDefault("P_RUC");
                    ObjProveedor.EMAIL_1 = command.Parameters.GetStringOrDefault("P_EMAIL_1");
                    ObjProveedor.EMAIL_2 = command.Parameters.GetStringOrDefault("P_EMAIL_2");
                    ObjProveedor.EMAIL_3 = command.Parameters.GetStringOrDefault("P_EMAIL_3");
                    ObjProveedor.TELEFONO_1 = command.Parameters.GetStringOrDefault("P_TELEFONO_1");
                    ObjProveedor.TELEFONO_2 = command.Parameters.GetStringOrDefault("P_TELEFONO_2");
                    ObjProveedor.TELEFONO_3 = command.Parameters.GetStringOrDefault("P_TELEFONO_3");
                    ObjProveedor.ESTADO = command.Parameters.GetStringOrDefault("P_ESTADO");

                //}

            }

            return ObjProveedor;
        }

        public Temporada ListadoFechasXTemporada(string Temporada)
        {
            var ObjTemporada = new Temporada();

            using (var connection = new OracleConnection(_connectionString))
            {
                var command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = string.Concat(Globales_DAL.gs_PACKAGENAME, "SP_OBTENER_FECHAS_TEMPORADA");
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("P_TEMPORADA", OracleDbType.Char, 9, Temporada, ParameterDirection.Input);
                command.Parameters.Add("P_FECHA_INICIO", OracleDbType.Date).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_FECHA_FIN", OracleDbType.Date).Direction = ParameterDirection.Output;
               
                connection.Open();
                command.ExecuteNonQuery();

                
                ObjTemporada.FECHA_INICIO = Convert.ToDateTime(command.Parameters.GetDateTimeOrDefault("P_FECHA_INICIO"));
                ObjTemporada.FECHA_FIN = Convert.ToDateTime(command.Parameters.GetDateTimeOrDefault("P_FECHA_FIN"));              
                
            }

            return ObjTemporada;
        }

        public Cliente ObtenerEditarCliente(string sCliente)
        {
            var ObjCliente = new Cliente();

            using (var connection = new OracleConnection(_connectionString))
            {
                var command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = string.Concat(Globales_DAL.gs_PACKAGENAME, "SP_OBTENER_LISTA_CLI");
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("P_CLIENTE", OracleDbType.Char, 9, sCliente, ParameterDirection.Input);
                command.Parameters.Add("P_CLICODIGO", OracleDbType.Char, 9).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_NOMBRE", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_PATERNO", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_MATERNO", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_DOCUMENTO", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_NUMERO", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_FEC_NACIMIENTO", OracleDbType.Date).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_RANGO_EDAD", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_ESTADO_CIVIL", OracleDbType.Varchar2, 20).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_GENERO", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_PAIS", OracleDbType.Varchar2, 20).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_PAISNOM", OracleDbType.Varchar2, 20).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_DEPARTAMENTO", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_DIRECCION", OracleDbType.Varchar2, 200).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_IDIOMA", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_EMAIL_1", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_EMAIL_2", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_EMAIL_3", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_TELEFONO_1", OracleDbType.Varchar2, 20).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_TELEFONO_2", OracleDbType.Varchar2, 20).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_TELEFONO_3", OracleDbType.Varchar2, 20).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_NOTAS", OracleDbType.Varchar2, 200).Direction = ParameterDirection.Output;
                command.Parameters.Add("P_ESTADO", OracleDbType.Varchar2, 20).Direction = ParameterDirection.Output;
                
                connection.Open();
                command.ExecuteNonQuery();

                ObjCliente.CLIENTE = command.Parameters.GetStringOrDefault("P_CLICODIGO");
                ObjCliente.NOMBRE = command.Parameters.GetStringOrDefault("P_NOMBRE");
                ObjCliente.PATERNO = command.Parameters.GetStringOrDefault("P_PATERNO");
                ObjCliente.MATERNO = command.Parameters.GetStringOrDefault("P_MATERNO");
                ObjCliente.DOCUMENTO = command.Parameters.GetStringOrDefault("P_DOCUMENTO");
                ObjCliente.NUMERO = command.Parameters.GetStringOrDefault("P_NUMERO");
                ObjCliente.FEC_NACIMIENTO = command.Parameters.GetDateTimeOrDefault("P_FEC_NACIMIENTO");
                ObjCliente.RANGO_EDAD = command.Parameters.GetStringOrDefault("P_RANGO_EDAD");
                ObjCliente.ESTADO_CIVIL = command.Parameters.GetStringOrDefault("P_ESTADO_CIVIL");
                ObjCliente.GENERO = command.Parameters.GetStringOrDefault("P_GENERO");
                ObjCliente.PAIS = command.Parameters.GetStringOrDefault("P_PAIS");
                ObjCliente.NOMBRE_PAIS = command.Parameters.GetStringOrDefault("P_PAISNOM");
                ObjCliente.DEPARTAMENTO = command.Parameters.GetStringOrDefault("P_DEPARTAMENTO");
                ObjCliente.DIRECCION = command.Parameters.GetStringOrDefault("P_DIRECCION");
                ObjCliente.IDIOMA = command.Parameters.GetStringOrDefault("P_IDIOMA");
                ObjCliente.EMAIL = command.Parameters.GetStringOrDefault("P_EMAIL_1");
                ObjCliente.EMAIL_2 = command.Parameters.GetStringOrDefault("P_EMAIL_2");
                ObjCliente.EMAIL_3 = command.Parameters.GetStringOrDefault("P_EMAIL_3");
                ObjCliente.TELEFONO = command.Parameters.GetStringOrDefault("P_TELEFONO_1");
                ObjCliente.TELEFONO_2 = command.Parameters.GetStringOrDefault("P_TELEFONO_2");
                ObjCliente.TELEFONO_3 = command.Parameters.GetStringOrDefault("P_TELEFONO_3");
                ObjCliente.NOTAS = command.Parameters.GetStringOrDefault("P_NOTAS");
                ObjCliente.ESTADO = command.Parameters.GetStringOrDefault("P_ESTADO");
            }
            return ObjCliente;
        }

        public IEnumerable<Tarifa_Detalle> ObtenerTarifProvDetalle(string sProveedor,string sTarifa)
        {
            var lstTarifaDetalle = new List<Tarifa_Detalle>();

            using (var connection = new OracleConnection(_connectionString))
            {
                var command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = string.Concat(Globales_DAL.gs_PACKAGENAME, "SP_LISTAR_TARIF_PROV_DET");
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("P_PROVEEDOR", OracleDbType.Varchar2, 100, sProveedor, ParameterDirection.Input);
                command.Parameters.Add("P_TARIFA", OracleDbType.Varchar2, 100, sTarifa, ParameterDirection.Input);
                command.Parameters.Add("P_RECORDSET", OracleDbType.RefCursor, ParameterDirection.Output);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tarifadetalle = new Tarifa_Detalle();
                        tarifadetalle.PROVEEDOR = reader.GetStringOrDefault(0);
                        tarifadetalle.TARIFA = reader.GetStringOrDefault(1);
                        tarifadetalle.SERVICIO = reader.GetStringOrDefault(2);
                        tarifadetalle.DESCRIPCION  = reader.GetStringOrDefault(3);
                        tarifadetalle.RANGO_DEL = reader.GetStringOrDefault(4);
                        tarifadetalle.RANGO_AL = reader.GetStringOrDefault(5);
                        tarifadetalle.PRECIO = reader.GetStringOrDefault(6);
                        lstTarifaDetalle.Add(tarifadetalle);
                    }
                }
            }

            return lstTarifaDetalle;
        }

        public void GuardarTarifa_Lista_Detalle(List<Tarifa_Detalle> lsttarifa)
        {
            foreach (var eEntidad in lsttarifa)
                GuardarTarifa_Detalle(eEntidad);
        }

        private void GuardarTarifa_Detalle(Tarifa_Detalle eEntidad)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                var command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = string.Concat(Globales_DAL.gs_PACKAGENAME, "SP_CREAR_TARIFA_DETALLE");
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("P_PROVEEDOR", OracleDbType.Varchar2, 100).Value = eEntidad.PROVEEDOR;
                command.Parameters.Add("P_TARIFA", OracleDbType.Varchar2, 100).Value = eEntidad.TARIFA;
                command.Parameters.Add("P_SERVICIO", OracleDbType.Varchar2, 50).Value = eEntidad.SERVICIO;
                command.Parameters.Add("P_DESCRIPCION", OracleDbType.Varchar2, 50).Value = eEntidad.DESCRIPCION;
                command.Parameters.Add("P_RANGO_DEL", OracleDbType.Varchar2, 100).Value = eEntidad.RANGO_DEL;
                command.Parameters.Add("P_RANGO_AL", OracleDbType.Varchar2, 100).Value = eEntidad.RANGO_AL;
                command.Parameters.Add("P_PRECIO", OracleDbType.Varchar2, 100).Value = eEntidad.PRECIO;                

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void GuardarServicio_Lista_Detalle(List<Servicio> lstCargaServ)
        {
            foreach (var eEntidad in lstCargaServ)
                GuardarServicioCarga_Detalle(eEntidad);
        }

        private void GuardarServicioCarga_Detalle(Servicio eEntidad)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                var command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = string.Concat(Globales_DAL.gs_PACKAGENAME, "SP_CREAR_SERVICIO");
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("P_PROVEEDOR", OracleDbType.Varchar2, 50).Value = eEntidad.PROVEEDOR;
                command.Parameters.Add("P_NOMBRE", OracleDbType.Varchar2, 50).Value = eEntidad.NOMBRE;
                command.Parameters.Add("P_TIPO", OracleDbType.Varchar2, 50).Value = null;
                command.Parameters.Add("P_VALORXSERVICIO", OracleDbType.Varchar2, 50).Value = null;
                command.Parameters.Add("P_VALOR", OracleDbType.Varchar2, 50).Value = null;
                command.Parameters.Add("P_DURACION", OracleDbType.Varchar2, 50).Value = null;
                command.Parameters.Add("P_TURNO", OracleDbType.Varchar2, 50).Value = null;
                command.Parameters.Add("P_DESAYUNO", OracleDbType.Varchar2, 50).Value = null;
                command.Parameters.Add("P_ALMUERZO", OracleDbType.Varchar2, 50).Value = null;
                command.Parameters.Add("P_CENA", OracleDbType.Varchar2, 50).Value = null;
                command.Parameters.Add("P_AEROLINEA", OracleDbType.Varchar2, 50).Value = eEntidad.AEROLINEA;
                command.Parameters.Add("P_BOX_LUNCH", OracleDbType.Varchar2, 50).Value = eEntidad.BOX_LUNCH;
                command.Parameters.Add("P_RUTA", OracleDbType.Varchar2, 50).Value = eEntidad.RUTA;
                command.Parameters.Add("P_DESCRIPCION", OracleDbType.Varchar2, 50).Value = eEntidad.DESCRIPCION;
                command.Parameters.Add("P_TIPO_SERVICIO", OracleDbType.Varchar2, 50).Value = eEntidad.TIPO_SERVICIO;
                command.Parameters.Add("P_TIPO_PERSONA", OracleDbType.Varchar2, 50).Value = eEntidad.TIPO_PERSONA;
                command.Parameters.Add("P_DESC_ESP", OracleDbType.Varchar2, 50).Value = eEntidad.DESC_ESP;
                command.Parameters.Add("P_DESC_INGL", OracleDbType.Varchar2, 50).Value = eEntidad.DESC_INGL;
                command.Parameters.Add("P_DESC_PORT", OracleDbType.Varchar2, 50).Value = eEntidad.DESC_PORT;
                command.Parameters.Add("P_DESC_ALE", OracleDbType.Varchar2, 50).Value = eEntidad.DESC_ALE;
                command.Parameters.Add("P_ESTADO", OracleDbType.Varchar2, 50).Value = 1;
                command.Parameters.Add("P_USUARIO_REGISTRO", OracleDbType.Varchar2, 50).Value = eEntidad.USUARIO_REGISTRO;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }



    }



    public static class OracleExtensions
    {
        public static string GetStringOrDefault(this OracleDataReader reader, int index)
        {
            if (reader.IsDBNull(index))
            {
                return string.Empty;
            }

            var value = reader.GetString(index);

            if ("null" == value.ToLower())
            {
                return string.Empty;
            }

            return value;
        }

        public static string GetStringOrDefault(this OracleDataReader reader, string name)
        {
            return GetStringOrDefault(reader, reader.GetOrdinal(name));
        }

        public static DateTime? GetDateTimeOrDefault(this OracleDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? (DateTime?)null : reader.GetDateTime(index);
        }

        public static DateTime? GetDateTimeOrDefault(this OracleDataReader reader, string name)
        {
            return GetDateTimeOrDefault(reader, reader.GetOrdinal(name));
        }

        public static decimal? GetDecimalOrDefault(this OracleDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? (decimal?)null : reader.GetDecimal(index);
        }

        public static decimal? GetDecimalOrDefault(this OracleDataReader reader, string name)
        {
            return GetDecimalOrDefault(reader, reader.GetOrdinal(name));
        }

        public static byte[] GetBlobOrDefault(this OracleDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? (byte[])null : (byte[])reader.GetValue(index);
        }

        public static byte[] GetBlobOrDefault(this OracleDataReader reader, string name)
        {
            return GetBlobOrDefault(reader, reader.GetOrdinal(name));
        }



        public static string GetStringOrDefault(this OracleParameterCollection parameters, string name)
        {
            var value = parameters[name].Value;

            if (DBNull.Value == value || value == null)
            {
                return string.Empty;
            }

            if ("null" == value.ToString().ToLower())
            {
                return string.Empty;
            }

            return value.ToString();
        }

        public static DateTime? GetDateTimeOrDefault(this OracleParameterCollection parameters, string name)
        {
            var value = parameters[name].Value;

            if (DBNull.Value == value || value == null)
            {
                return null;
            }

            if (value is DateTime)
            {
                return (DateTime)value;
            }

            return Convert.ToDateTime(value.ToString());
        }

        public static decimal? GetDecimalOrDefault(this OracleParameterCollection parameters, string name)
        {
            var value = parameters[name].Value;

            if (DBNull.Value == value || value == null)
            {
                return null;
            }

            if (value is decimal)
            {
                return (decimal)value;
            }

            try
            {
                return Convert.ToDecimal(value.ToString());
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static byte[] GetBlobOrDefault(this OracleParameterCollection parameters, string name)
        {
            var value = parameters[name].Value;

            if (DBNull.Value == null || value == null)
            {
                return null;
            }

            return (byte[])value;
        }
    }
}
