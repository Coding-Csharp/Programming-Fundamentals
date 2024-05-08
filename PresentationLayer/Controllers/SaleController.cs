using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    // CLASE PARCIAL ENCARGADA DE DEFINIR LOS ATRIBUTOS Y LA INICIALIZACION DE LOS DATOS EN EL CONSTRUCTOR
    public partial class SaleController
    {
        private List<Client> Clients;
        private List<Product> Products;
        private Invoice InvoiceData;

        public SaleController()
        {
            this.Clients = [];
            this.Products = [];
            this.InvoiceData = new();
        }
    }

    // CLASE PARCIAL ENCARGADA DE DEFINIR METODOS LOGICOS PARA LA APLICACION
    public partial class SaleController
    {
        private void GenerateClients()
        {
            Clients =
            [
                new() { Id = 74758394, Name = "Aaron", LastName = "Alarcon", Age = 21 },
                new() { Id = 76784533, Name = "Pedro", LastName = "Bardales", Age = 19 },
                new() { Id = 72245667, Name = "Mauricio", LastName = "Rokjas", Age = 27 }
            ];
        }
        private void GenerateProducts()
        {
            Products =
            [
                new() { Id = 1, Name = "Platano", Price = 3.50, Stock = 10 },
                new() { Id = 2, Name = "Lechuga", Price = 1.30, Stock = 14 },
                new() { Id = 3, Name = "Cebolla", Price = 3.50, Stock = 18 }
            ];
        }
        private bool ValidateIdProduct(int Id)
        {
            Product? Result = Products.Where(P => P.Id == Id).FirstOrDefault(); // USAMOS EXPRESIONES LAMBDA PARA VERIFICAR LA EXISTENCIA DEL PRODUCTO

            if (Result is null) { return false; } //VALIDAMOS SI EL RESULTADO DE LA BUSQUEDA FUE EXITOSA O NO
            else { return true; }
        }
        private bool ValidateIdClient(int Id)
        {
            Client? Result = Clients.Where(C => C.Id == Id).FirstOrDefault(); // USAMOS EXPRESIONES LAMBDA PARA VERIFICAR LA EXISTENCIA DEL CLIENTE

            if (Result is null) return false; //VALIDAMOS SI EL RESULTADO DE LA BUSQUEDA FUE EXITOSA O NO
            else return true;
        }
        private void ShowProducts()
        {
            // RECORREMOS LA LISTA DE PRODUCTOS
            foreach (var Product in Products)
            {
                Console.WriteLine("Id: " + Product.Id + "\t| " + "Nombre: " + Product.Name + "\t| " +
                    "Precio: " + Product.Price + "\t| " + "Stock: " + Product.Stock);
            }
        }
        private int SelectOptions()
        {
            Console.WriteLine("1) FINALIZAR COMPRA");
            Console.WriteLine("2) SEGUIR COMPRANDO");
            Console.WriteLine("3) SALIR");

            return Convert.ToInt32(Console.ReadLine());
        }
    }

    // CLASE PARCIAL ENCARGADA DE MOSTRAR LA INTERFAZ
    public partial class SaleController
    {
        public void RunApp()
        {
            // LLAMAMOS A LOS METODOS QUE GENERAN Y MUESTRAN DATOS
            GenerateClients();

            int IdClient;
            int IdProduct;
            bool Status = true;

            Console.WriteLine("ESCRIBA SU ID: ");
            IdClient = Convert.ToInt32(Console.ReadLine());

            if (ValidateIdClient(IdClient))
            {
                while (Status)
                {
                    Console.Clear();

                    GenerateProducts();
                    ShowProducts();

                    Console.WriteLine("ESCRIBA EL ID DEL PRODUCTO QUE DESEA: ");

                    IdProduct = Convert.ToInt32(Console.ReadLine()); // CAPTURAMOS EL ID INGRESADO POR EL USUARIO Y SE CONVIERTE A UN ENTERO

                    if (ValidateIdProduct(IdProduct))
                    {
                        InvoiceData.InvoiceDetailData.ProductsDataList.Add(Products.Where(P => P.Id == IdProduct).First()); // AGREAMOS EL PRODUCTO AL DETALLE DE LA BOLETA

                        Console.WriteLine("PRODUCTO AGREGADO");

                        switch (SelectOptions())
                        {
                            case 1:

                                Console.Clear();

                                InvoiceData.Id++; // GENERAMOS UN ID PARA LA FACTURA
                                InvoiceData.ClientData = Clients.Where(C => C.Id == IdClient).First(); // OBTENEMOS LOS DATOS DEL CLIENTE QUE HA REALIZADO LA COMPRA
                                InvoiceData.SaleDate = DateTime.UtcNow; // ESTABLECEMOS LA FECHA ACTUAL

                                //MOSTRAMOS LA CABECERA QUE TIENE UNA FACTURA CON LOS DATOS DEL CLIENTE
                                Console.WriteLine("---------- FACTURA DE VENTA ----------\n");
                                Console.WriteLine("ID FACTURA: " + InvoiceData.Id);
                                Console.WriteLine("DNI: " + InvoiceData.ClientData.Id);
                                Console.WriteLine("CLIENTE: " + InvoiceData.ClientData.Name);
                                Console.WriteLine("FECHA: " + InvoiceData.SaleDate + "\n");

                                Console.WriteLine("DETALLE DE VENTA\n");

                                // MOSTRAMOS LA LISTA DE PRODUCTOS QUE FUERON COMPRADOS
                                foreach (var InvoiceDetail in InvoiceData.InvoiceDetailData.ProductsDataList)
                                {
                                    Console.WriteLine("Id: " + InvoiceDetail.Id + "\t| " + "Nombre: " + InvoiceDetail.Name + "\t| " +
                                                      "Precio: " + InvoiceDetail.Price);
                                }

                                Status = false;

                                break;
                            case 2: break;
                            case 3: Status = false; break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("PRODUCTO NO EXISTENTE");
                    }
                }
            }
            else
            {
                Console.WriteLine("CLIENTE NO EXISTENTE");
            }
        }
    }
}