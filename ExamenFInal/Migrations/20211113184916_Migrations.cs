using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamenFInal.Migrations
{
    public partial class Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "proveedoro",
                columns: table => new
                {
                    IdProveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Proveedor = table.Column<string>(type: "varchar(35)", nullable: false),
                    Direccion = table.Column<string>(type: "varchar(50)", nullable: false),
                    telefono = table.Column<string>(type: "varchar(15)", nullable: false),
                    correo = table.Column<string>(type: "varchar(50)", nullable: false),
                    EstadoProveedor = table.Column<string>(type: "varchar(3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proveedoro", x => x.IdProveedor);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProveedor = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    Producto = table.Column<string>(type: "varchar(35)", nullable: false),
                    TipoProducto = table.Column<string>(type: "varchar(35)", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(50)", nullable: false),
                    Precio = table.Column<double>(type: "float(35)", nullable: false),
                    EstadoProducto = table.Column<string>(type: "varchar(3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_productos_proveedoro_IdProveedor",
                        column: x => x.IdProveedor,
                        principalTable: "proveedoro",
                        principalColumn: "IdProveedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bodega",
                columns: table => new
                {
                    IdBodega = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    cantidadProducto = table.Column<int>(type: "int", nullable: false),
                    NombreBodega = table.Column<string>(type: "varchar(35)", nullable: false),
                    Direccion = table.Column<string>(type: "varchar(35)", nullable: false),
                    telefono = table.Column<string>(type: "varchar(35)", nullable: false),
                    correo = table.Column<string>(type: "varchar(35)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bodega", x => x.IdBodega);
                    table.ForeignKey(
                        name: "FK_Bodega_productos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bodega_IdProducto",
                table: "Bodega",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_productos_IdProveedor",
                table: "productos",
                column: "IdProveedor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bodega");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "proveedoro");
        }
    }
}
