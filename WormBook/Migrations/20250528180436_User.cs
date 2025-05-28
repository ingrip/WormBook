using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WormBook.Migrations
{
    /// <inheritdoc />
    public partial class User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "CLIENTE_SEQ");

            migrationBuilder.CreateSequence(
                name: "ENVIO_SEQ");

            migrationBuilder.CreateSequence(
                name: "PEDIDOESPECIAL_SEQ");

            migrationBuilder.CreateSequence(
                name: "PRODUCTO_SEQ");

            migrationBuilder.CreateSequence(
                name: "REPOPEDIDO_SEQ");

            migrationBuilder.CreateSequence(
                name: "SUCURSAL_SEQ");

            migrationBuilder.CreateSequence(
                name: "VENTA_SEQ");

            migrationBuilder.CreateTable(
                name: "CLIENTE",
                columns: table => new
                {
                    IDCLIENTE = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOMBRE = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: false),
                    APELLIDO = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: false),
                    TELEFONO = table.Column<string>(type: "VARCHAR2(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTE", x => x.IDCLIENTE);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTO",
                columns: table => new
                {
                    CODIGOINTERNO = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PRECIO = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: true),
                    CODIGOBARRAS = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTO", x => x.CODIGOINTERNO);
                });

            migrationBuilder.CreateTable(
                name: "SUCURSAL",
                columns: table => new
                {
                    CODIGOSUCURSAL = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOMBRESUCURSAL = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: false),
                    UBICACION = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: false),
                    TELEFONOSUCURSAL = table.Column<string>(type: "VARCHAR2(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUCURSAL", x => x.CODIGOSUCURSAL);
                });

            migrationBuilder.CreateTable(
                name: "JUEGOMESA",
                columns: table => new
                {
                    CODIGOINTERNO = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false),
                    NOMBRE = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: false),
                    MARCA = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: false),
                    URL = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JUEGOMESA", x => x.CODIGOINTERNO);
                    table.ForeignKey(
                        name: "FK_JUEGOMESA_PRODUCTO",
                        column: x => x.CODIGOINTERNO,
                        principalTable: "PRODUCTO",
                        principalColumn: "CODIGOINTERNO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LIBRO",
                columns: table => new
                {
                    CODIGOINTERNO = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false),
                    TITULO = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: false),
                    AUTOR = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: false),
                    ISBN = table.Column<string>(type: "VARCHAR2(20)", unicode: false, maxLength: 20, nullable: false),
                    EDITORIAL = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LIBRO", x => x.CODIGOINTERNO);
                    table.ForeignKey(
                        name: "FK_LIBRO_PRODUCTO",
                        column: x => x.CODIGOINTERNO,
                        principalTable: "PRODUCTO",
                        principalColumn: "CODIGOINTERNO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TARJETAREGALO",
                columns: table => new
                {
                    CODIGOINTERNO = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false),
                    SALDO = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TARJETAREGALO", x => x.CODIGOINTERNO);
                    table.ForeignKey(
                        name: "FK_TARJETAREGALO_PRODUCTO",
                        column: x => x.CODIGOINTERNO,
                        principalTable: "PRODUCTO",
                        principalColumn: "CODIGOINTERNO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ENVIO",
                columns: table => new
                {
                    GUIAENVIO = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NUMCAJAS = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false),
                    SUCURSALDESTINO = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false),
                    SUCURSALORIGEN = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENVIO", x => x.GUIAENVIO);
                    table.ForeignKey(
                        name: "FK_ENVIO_SUCURSALDESTINO",
                        column: x => x.SUCURSALDESTINO,
                        principalTable: "SUCURSAL",
                        principalColumn: "CODIGOSUCURSAL");
                    table.ForeignKey(
                        name: "FK_ENVIO_SUCURSALORIGEN",
                        column: x => x.SUCURSALORIGEN,
                        principalTable: "SUCURSAL",
                        principalColumn: "CODIGOSUCURSAL");
                });

            migrationBuilder.CreateTable(
                name: "EXISTENCIA",
                columns: table => new
                {
                    CODIGOINTERNO = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false),
                    CODIGOSUCURSAL = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false),
                    EXISTENCIA = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXISTENCIA", x => new { x.CODIGOINTERNO, x.CODIGOSUCURSAL });
                    table.ForeignKey(
                        name: "FK_EXISTENCIA_PRODUCTO",
                        column: x => x.CODIGOINTERNO,
                        principalTable: "PRODUCTO",
                        principalColumn: "CODIGOINTERNO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EXISTENCIA_SUCURSAL",
                        column: x => x.CODIGOSUCURSAL,
                        principalTable: "SUCURSAL",
                        principalColumn: "CODIGOSUCURSAL");
                });

            migrationBuilder.CreateTable(
                name: "PEDIDOESPECIAL",
                columns: table => new
                {
                    NUMPEDIDO = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    FECHAPEDIDO = table.Column<DateTime>(type: "DATE", nullable: false),
                    CANTIDADPEDIDA = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false),
                    ESTADO = table.Column<string>(type: "VARCHAR2(20)", unicode: false, maxLength: 20, nullable: false),
                    CODIGOINTERNO = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false),
                    CODIGOSUCURSAL = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false),
                    IDCLIENTE = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEDIDOESPECIAL", x => x.NUMPEDIDO);
                    table.ForeignKey(
                        name: "FK_PEDIDOESPECIAL_CLIENTE",
                        column: x => x.IDCLIENTE,
                        principalTable: "CLIENTE",
                        principalColumn: "IDCLIENTE");
                    table.ForeignKey(
                        name: "FK_PEDIDOESPECIAL_PRODUCTO",
                        column: x => x.CODIGOINTERNO,
                        principalTable: "PRODUCTO",
                        principalColumn: "CODIGOINTERNO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PEDIDOESPECIAL_SUCURSAL",
                        column: x => x.CODIGOSUCURSAL,
                        principalTable: "SUCURSAL",
                        principalColumn: "CODIGOSUCURSAL");
                });

            migrationBuilder.CreateTable(
                name: "REPOPEDIDO",
                columns: table => new
                {
                    NUMREPO = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CODIGOSUCURSAL = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false),
                    FECHAPEDIDO = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REPOPEDIDO", x => x.NUMREPO);
                    table.ForeignKey(
                        name: "FK_REPOPEDIDO_SUCURSAL",
                        column: x => x.CODIGOSUCURSAL,
                        principalTable: "SUCURSAL",
                        principalColumn: "CODIGOSUCURSAL");
                });

            migrationBuilder.CreateTable(
                name: "VENTA",
                columns: table => new
                {
                    NUMVENTA = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TOTAL = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: true),
                    FECHACOMPRA = table.Column<DateTime>(type: "DATE", nullable: true),
                    CODIGOSUCURSAL = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VENTA", x => x.NUMVENTA);
                    table.ForeignKey(
                        name: "FK_VENTA_SUCURSAL",
                        column: x => x.CODIGOSUCURSAL,
                        principalTable: "SUCURSAL",
                        principalColumn: "CODIGOSUCURSAL");
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTOSENVIADOS",
                columns: table => new
                {
                    CODIGOINTERNO = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false),
                    GUIAENVIO = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false),
                    CANTIDADENVIADA = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false),
                    NOVEDAD = table.Column<string>(type: "VARCHAR2(20)", unicode: false, maxLength: 20, nullable: false),
                    NUMPEDIDOESP = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTOSENVIADOS", x => new { x.CODIGOINTERNO, x.GUIAENVIO });
                    table.ForeignKey(
                        name: "FK_PRODUCTOSENVIADOS_ENVIO",
                        column: x => x.GUIAENVIO,
                        principalTable: "ENVIO",
                        principalColumn: "GUIAENVIO");
                    table.ForeignKey(
                        name: "FK_PRODUCTOSENVIADOS_PEDIDOESPECIAL",
                        column: x => x.NUMPEDIDOESP,
                        principalTable: "PEDIDOESPECIAL",
                        principalColumn: "NUMPEDIDO");
                    table.ForeignKey(
                        name: "FK_PRODUCTOSENVIADOS_PRODUCTO",
                        column: x => x.CODIGOINTERNO,
                        principalTable: "PRODUCTO",
                        principalColumn: "CODIGOINTERNO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "REPODETALLES",
                columns: table => new
                {
                    CODIGOINTERNO = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false),
                    NUMREPO = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false),
                    CANTIDAD = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REPODETALLES", x => new { x.CODIGOINTERNO, x.NUMREPO });
                    table.ForeignKey(
                        name: "FK_REPODETALLES_PRODUCTO",
                        column: x => x.CODIGOINTERNO,
                        principalTable: "PRODUCTO",
                        principalColumn: "CODIGOINTERNO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_REPODETALLES_REPOPEDIDO",
                        column: x => x.NUMREPO,
                        principalTable: "REPOPEDIDO",
                        principalColumn: "NUMREPO");
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTOVENDIDO",
                columns: table => new
                {
                    CODIGOINTERNO = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false),
                    NUMVENTA = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false),
                    CANTIDADVENDIDA = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTOVENDIDO", x => new { x.CODIGOINTERNO, x.NUMVENTA });
                    table.ForeignKey(
                        name: "FK_PRODUCTOVENDIDO_PRODUCTO",
                        column: x => x.CODIGOINTERNO,
                        principalTable: "PRODUCTO",
                        principalColumn: "CODIGOINTERNO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRODUCTOVENDIDO_VENTA",
                        column: x => x.NUMVENTA,
                        principalTable: "VENTA",
                        principalColumn: "NUMVENTA");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ENVIO_SUCURSALDESTINO",
                table: "ENVIO",
                column: "SUCURSALDESTINO");

            migrationBuilder.CreateIndex(
                name: "IX_ENVIO_SUCURSALORIGEN",
                table: "ENVIO",
                column: "SUCURSALORIGEN");

            migrationBuilder.CreateIndex(
                name: "IX_EXISTENCIA_CODIGOSUCURSAL",
                table: "EXISTENCIA",
                column: "CODIGOSUCURSAL");

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDOESPECIAL_CODIGOINTERNO",
                table: "PEDIDOESPECIAL",
                column: "CODIGOINTERNO");

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDOESPECIAL_CODIGOSUCURSAL",
                table: "PEDIDOESPECIAL",
                column: "CODIGOSUCURSAL");

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDOESPECIAL_IDCLIENTE",
                table: "PEDIDOESPECIAL",
                column: "IDCLIENTE");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTOSENVIADOS_GUIAENVIO",
                table: "PRODUCTOSENVIADOS",
                column: "GUIAENVIO");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTOSENVIADOS_NUMPEDIDOESP",
                table: "PRODUCTOSENVIADOS",
                column: "NUMPEDIDOESP");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTOVENDIDO_NUMVENTA",
                table: "PRODUCTOVENDIDO",
                column: "NUMVENTA");

            migrationBuilder.CreateIndex(
                name: "IX_REPODETALLES_NUMREPO",
                table: "REPODETALLES",
                column: "NUMREPO");

            migrationBuilder.CreateIndex(
                name: "IX_REPOPEDIDO_CODIGOSUCURSAL",
                table: "REPOPEDIDO",
                column: "CODIGOSUCURSAL");

            migrationBuilder.CreateIndex(
                name: "IX_VENTA_CODIGOSUCURSAL",
                table: "VENTA",
                column: "CODIGOSUCURSAL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EXISTENCIA");

            migrationBuilder.DropTable(
                name: "JUEGOMESA");

            migrationBuilder.DropTable(
                name: "LIBRO");

            migrationBuilder.DropTable(
                name: "PRODUCTOSENVIADOS");

            migrationBuilder.DropTable(
                name: "PRODUCTOVENDIDO");

            migrationBuilder.DropTable(
                name: "REPODETALLES");

            migrationBuilder.DropTable(
                name: "TARJETAREGALO");

            migrationBuilder.DropTable(
                name: "ENVIO");

            migrationBuilder.DropTable(
                name: "PEDIDOESPECIAL");

            migrationBuilder.DropTable(
                name: "VENTA");

            migrationBuilder.DropTable(
                name: "REPOPEDIDO");

            migrationBuilder.DropTable(
                name: "CLIENTE");

            migrationBuilder.DropTable(
                name: "PRODUCTO");

            migrationBuilder.DropTable(
                name: "SUCURSAL");

            migrationBuilder.DropSequence(
                name: "CLIENTE_SEQ");

            migrationBuilder.DropSequence(
                name: "ENVIO_SEQ");

            migrationBuilder.DropSequence(
                name: "PEDIDOESPECIAL_SEQ");

            migrationBuilder.DropSequence(
                name: "PRODUCTO_SEQ");

            migrationBuilder.DropSequence(
                name: "REPOPEDIDO_SEQ");

            migrationBuilder.DropSequence(
                name: "SUCURSAL_SEQ");

            migrationBuilder.DropSequence(
                name: "VENTA_SEQ");
        }
    }
}
