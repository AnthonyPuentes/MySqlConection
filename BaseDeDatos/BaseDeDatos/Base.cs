using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace BaseDeDatos
{
    class Base
    {
       
        protected Db db = new Db();
        public void Menu()
        {


            string opcion;
            do
            {
                Console.WriteLine("\n\t\t************** Menu Principal *****************");
                Console.WriteLine("\n\n\t1.-Mostrar los Datos\n\n\t2.-Agregar\n\n\t3.-Modificar\n\n\t4.-Eliminar\n\n\t5.-Salir");

                opcion = Console.ReadLine();

                if (opcion != "5")
                {
                   
                    Metodos(opcion);
                    Console.WriteLine("\n\t****Presione cualquier tecla para regresar al menu de opciones*********");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            while (opcion != "5");
            this.Final();

        }



        public void Metodos(string opcion)
        {



            switch (opcion)
            {

                case "1":
                    Console.Clear();
                    Console.WriteLine("\n\t\t************ Mostrando Base de Datos **********");
                    Mostrar();

                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("\n\t\t****************** Agregando ********************");
                    Agregar();
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("\n\t\t****************** Editando ********************");
                    Editar();
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("\n\t\t****************** Eliminando ********************");
                    Eliminar();

                    break;

                case "5":
                    
                    
                    break;
                default:
                    Console.WriteLine("************ Esta opcion no existe ************");
                    break;



            }


        }

        public void Mostrar()
        {
            this.db.mostrarDatos();
        }

        public void Agregar() {

            string consultar = "INSERT INTO persona VALUES('',";

            Console.Write("\t\tNombre: ");
            consultar += "'" + Console.ReadLine() + "', ";
            Console.Write("\t\tCodigo: ");
            consultar += "'" + Console.ReadLine() + "', ";
            Console.Write("\t\tTelefono: ");
            consultar += "'" + Console.ReadLine() + "', ";
            Console.Write("\t\temail: ");
            consultar += "'" + Console.ReadLine() + "' )";

            this.db.Consulta(consultar);
        
        }

        public void Editar() {
            this.db.mostrarDatos();

            Console.Write("\n\tEscriba el id de la tupla a editar o \"S\" para cancelar: ");

            string tecleado = Console.ReadLine();

            if (tecleado == "s" || tecleado == "S")
                return;
            else 
            {
                Console.Write("\n\tRealmente quiere editar la tupla con el id " + tecleado + " (c para continuar):");

            string corroboracion = Console.ReadLine();

                if (corroboracion == "c" || corroboracion == "C") 
                { 
                    int oprimido;

                    if (Int32.TryParse(tecleado, out oprimido))
                    {
                        if (this.db.verificarExistencia(oprimido)) 
                        {
                            string valores = "";
                            Console.WriteLine("\t\tEditando id: " + oprimido);
                            Console.Write("\t\tNombre: ");
                            valores += "nombre='" + Console.ReadLine() + "', ";
                            Console.Write("\t\tCodigo: ");
                            valores += "codigo='" + Console.ReadLine() + "', ";
                            Console.Write("\t\tTelefono: ");
                            valores += "telefono='" + Console.ReadLine() + "', ";
                            Console.Write("\t\temail: ");
                            valores += "email='" + Console.ReadLine() + "'";

                            this.db.Consulta("UPDATE persona SET " + valores + " WHERE id=" + oprimido);
                        }
                        else
                            Console.WriteLine("\n\t\tEl id no existe, favor de  validarlo.");
                    }
                    else
                        Console.WriteLine("\n\tSolo se aceptan numeros enteros.");
                }
            }
        }
        private void Eliminar()
        {
            this.db.mostrarDatos();

            Console.Write("\n\t Escriba el id de la tupla a eliminar o \"s\" para cancelar: ");
            string tecleado = Console.ReadLine();

            if (tecleado == "s" || tecleado == "S")
                return;
            else
            {
                Console.Write("\n\tQuiere editar la tupla con el id " + tecleado + " (c para continuar):");
            string corroboracion = Console.ReadLine();

                if (corroboracion == "c" || corroboracion == "C") 
                { 
                    int oprimido;
                    if (Int32.TryParse(tecleado, out oprimido))
                    {
                        if (this.db.verificarExistencia(oprimido))
                            this.db.Consulta("DELETE FROM persona WHERE id=" + oprimido);
                        else
                            Console.WriteLine("\n\t\tEl id  no existe, verifiquelo.");
                    }
                    else
                        Console.WriteLine("\n\tSolo se aceptan numeros enteros.");
                }
            }
        }

         private void Final()
        {
             Console.WriteLine("\n\t\t\tPresione cualquier tecla finalizar...\n\t\t\t  ");
   
        }

        
        }




    }



    


