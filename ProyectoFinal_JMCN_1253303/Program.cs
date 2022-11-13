using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_JMCN_1253303
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido a su asistente de automatización");
            Console.WriteLine("Por favor, escriba su nombre: ");

            string nombre = (Console.ReadLine());
    

            Console.WriteLine("Gracias  " + nombre);
            Console.WriteLine("Seleccione una opción por favor:"+"\n");
            Console.WriteLine("Presione 1 para entrar al Sistema de Ventilación");
            Console.WriteLine("Presione 2 para entrar al Sistema de Calefacción");
            Console.WriteLine("Presione 3 para entrar al Sistema de Iluminación");
            Console.WriteLine("Presione 4 para salir del sistema");

            int opcion= Convert.ToInt32(Console.ReadLine());
            
            switch (opcion)
            {

                case 1:

                    DateTime dateTime = DateTime.Now;
                    string hora = dateTime.ToString("HH:mm");
                    
                    Console.WriteLine("Bienvenido al control de ventilación"+"\n");
                    Console.WriteLine("Hora:"+hora);

                   //Humedad 
                    Random Random = new Random();
                    int aleatorio = Random.Next(30, 80);

                    Console.WriteLine("Status de humedad actual: "+aleatorio+"%");
                    if (Convert.ToInt32(aleatorio) > 70) 
                    {
                        Console.WriteLine("Humedad alta detectada: Sistema de ventilación activandose"+"\n");
                    }
                    else
                        Console.WriteLine("Humedad adecuada"+"\n");

                    // Programación de horas de ventilacion 
                    DateTime dateTime2 = DateTime.Now;
                    string hora2 = dateTime2.ToString("HH");
                   
                    if(Convert.ToInt32(hora2)>6 && Convert.ToInt32(hora2) < 18)//mod18
                    {
                        Console.WriteLine("Actualmente se encuentra en Progrmación DIA [ 7:00h a 18:00h]" + "\n" );
                        Console.WriteLine("Determinar memorias de activación del sistema de ventilación: "+"\n");
                        Console.WriteLine("Ingrese hora (formato H 24h) en horario de 6 a 18h"+"\n");

                       //Programación #1
                        Console.WriteLine("Programación #1");
                        Console.WriteLine("Hora Inicio [Formato H, 24h]");
                        int p1i=Convert.ToInt32(Console.ReadLine());
                        if (p1i<7 || p1i > 18) //mod 18
                        {
                            Console.WriteLine("Horario fuera de oficina, Ingrese de nuevo. El sistema se reinicia");
                            Console.ReadKey();
                            return;
                        }

                        Console.WriteLine("Duración[h]");
                        int p1h = Convert.ToInt32(Console.ReadLine());

                        int pr1 = p1h - p1i;
                        int ph1 = p1h + pr1;
                        int pt1 = p1h + p1i;


                        if ( ph1 > 12)
                        {
                            Console.WriteLine(" No es permitido: Cantidad de horas deb estar dentro del horario laboral, ingrese de nuevo");
                            Console.ReadKey();
                            return;
                        }
                         Console.WriteLine("Programación #2");
                        Console.WriteLine("Ingrese la hora de inicio [Formato H, 24h]");

                        int p2i = Convert.ToInt32(Console.ReadLine());

                        if (p2i < 7 || p2i > 18) //mod 18
                        {
                            Console.WriteLine("Horario fuera de oficina, Ingrese de nuevo. El sistema se reinicia");
                            Console.ReadKey();
                            return;
                        }

                        for ( int contador = pt1 ; contador > 0; contador-- )

                        {
                           if (contador == p2i) 
                            
                            {
                                Console.WriteLine("Horario seleccionado en programación existente, ingrese de nuevo");
                                Console.ReadKey();
                                return;
                            }
                        }

                        Console.WriteLine("Duración [h]: ");
                        int p2h = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\n");

                        int pt2 = p2h + p2i;
                        int pr2 = p2h - p2i;    
                        
                        if (pr2 > 12)
                        {
                            Console.WriteLine(" No es permitido: Cantidad de horas debe estar dentro del horario laboral, ingrese de nuevo");
                            Console.ReadKey();
                            return;
                        }
                        Console.WriteLine("RESUMEN PROGRAMACIÓN VENTILACIÓN:"+"\n");
                        Console.WriteLine("PROGRMACION #1:");
                        Console.WriteLine("Operación: "+p1i+"h. - "+ pt1+"h");
                        Console.WriteLine("PROGRAMACION #2:");
                        Console.WriteLine("Operación: " + p2i + "h - " + pt2 +"h"+"\n");
                        Console.WriteLine("Sistema parametrizado, Muchas Gracias!");
                        Console.ReadKey();

                    }

                    else
                    {
                        Console.WriteLine("MODO NOCHE 18h a 6h:");
                        Console.WriteLine("Status: Autoregulación de ventilación nocturna en curso");
                        Console.WriteLine("Humedad y temperatura estables");
                        Console.ReadKey();
                    }
                    break;
                    


                case 2:

                    Console.WriteLine("Bienvenido al Control de Calefacción");

                    Console.WriteLine("Ingrese la habitación que desea configurar:"+"\n");
                    Console.WriteLine("Opción 1: Master Bedroom");
                    Console.WriteLine("Opción 2: Habitación secundaria");
                    Console.WriteLine("Opción 3: Sala Comedor");
                    Console.WriteLine("Opción 4: Salir");
                   
                    int opcion2 = Convert.ToInt32(Console.ReadLine());
                    //Selección de habitación 
                    switch (opcion2)
                    {
                        case (1):

                            Console.WriteLine("Bienvenido al Master Bedroom");
                            Console.WriteLine("Status");
                            Random r1 = new Random();
                            int t1 = r1.Next(09, 40);
 

                            Console.WriteLine("Ingrese parametro de temperatura Máxima [grados celsius]");
                           int h1t1 = Convert.ToInt32(Console.ReadLine());

                            if (h1t1 < 0 || h1t1 > 30)
                            {
                                Console.WriteLine("Temperatura no permitida excede paramtros de sistema de calefacción [17 a 30 grados]");
                                Console.ReadKey();
                            }

                            Console.WriteLine("Ingrese parametro de temperatura Mínima [grados celsius]");
                           int h1t2 = Convert.ToInt32(Console.ReadLine());

                            if (h1t2 < 0 || h1t1 > 30)
                            {
                                Console.WriteLine("Temperatura no permitida excede parámetros de sistema de calefacción [17 a 30 grados]");
                                Console.ReadKey();

                                
                            }
                            else if  (h1t2 > h1t1)
                            {
                                Console.WriteLine(" Advertencia:La temperarutra mínima no puede ser mayor a la máxima, vuelva a progrmar");
                                Console.ReadKey();
                            }


                           int h1tp = (h1t1 + h1t2) / 2;

                            Console.WriteLine("RESUMEN PROGRAMACION INGRESADA:");
                            Console.WriteLine("Temp. Max: "+h1t1+" grados Celsius");
                            Console.WriteLine("Temp. Mix: " + h1t2 + " grados Celsius");
                            Console.WriteLine("Temp. Promedio: " + h1tp + " grados Celsius"+"\n");

                          

                             Console.WriteLine("Temperatura en tiempo real de habitación: " + t1 + " grados celcius"+"\n");
                            if (Convert.ToInt32(t1) >h1t2 || Convert.ToInt32(t1)<h1t1)
                            {
                                Console.WriteLine("Status: Encendido");
                                Console.WriteLine("Sistema de calefacción operando para regular temperatura");
                                Console.ReadKey();
                            }
                            else
                                Console.WriteLine("Temperatura dentro de parametro: calefacción en stanby hasta detectar variación de temperatura" + "\n");
                            Console.ReadKey();

                            break;

                        case (2):

                            Console.WriteLine("Bienvenido a la Habitación Secundaria");
                            Console.WriteLine("Status");
                            Random r2 = new Random();
                            int t2 = r2.Next(09, 40);
                      

                            Console.WriteLine("Ingrese parametro de temperatura Máxima [grados celsius]");
                           int  h2t1 = Convert.ToInt32(Console.ReadLine());

                            if (h2t1 < 0 || h2t1 > 30)
                            {
                                Console.WriteLine("Temperatura no permitida excede paramtros de sistema de calefacción [17 a 30 grados]");
                                Console.ReadKey();
                            }

                            Console.WriteLine("Ingrese parametro de temperatura Mínima [grados celsius]");
                           int h2t2 = Convert.ToInt32(Console.ReadLine());

                            if (h2t2 < 0 || h2t1 > 30)
                            {
                                Console.WriteLine("Temperatura no permitida excede parámetros de sistema de calefacción [17 a 30 grados]");
                                Console.ReadKey();


                            }
                            else if (h2t2 > h2t1)
                            {
                                Console.WriteLine(" Advertencia:La temperarutra mínima no puede ser mayor a la máxima, vuelva a progrmar");
                                Console.ReadKey();
                            }


                           int h2tp = (h2t1 + h2t2) / 2;

                            Console.WriteLine("RESUMEN PROGRAMACION INGRESADA:");
                            Console.WriteLine("Temp. Max: " + h2t1 + " grados Celsius");
                            Console.WriteLine("Temp. Mix: " + h2t2 + " grados Celsius");
                            Console.WriteLine("Temp. Promedio: " + h2tp + " grados Celsius" + "\n");



                            Console.WriteLine("Temperatura en tiempo real de habitación: " + t2 + " grados celcius" + "\n");
                            if (Convert.ToInt32(t2) > h2t2 || Convert.ToInt32(t2) < h2t1)
                            {
                                Console.WriteLine("Status: Encendido");
                                Console.WriteLine("Sistema de calefacción operando para regular temperatura");
                                Console.ReadKey();
                            }
                            else
                                Console.WriteLine("Temperatura dentro de parametro: calefacción en stanby hasta detectar variación de temperatura" + "\n");
                            Console.ReadKey();
                            break;

                        case (3):


                            Console.WriteLine("Bienvenido a la Sala - Comedor");
                            Console.WriteLine("Status");
                            Random r3 = new Random();
                            int t3 = r3.Next(09, 40);


                           
                            
                            

                            Console.WriteLine("Ingrese parametro de temperatura Máxima [grados celsius]");
                           int h3t1 = Convert.ToInt32(Console.ReadLine());

                            if (h3t1 < 0 || h3t1 > 30)
                            {
                                Console.WriteLine("Temperatura no permitida excede paramtros de sistema de calefacción [17 a 30 grados]");
                                Console.ReadKey();
                            }

                            Console.WriteLine("Ingrese parametro de temperatura Mínima [grados celsius]");
                           int  h3t2 = Convert.ToInt32(Console.ReadLine());

                            if (h3t2 < 0 || h3t1 > 30)
                            {
                                Console.WriteLine("Temperatura no permitida excede parámetros de sistema de calefacción [17 a 30 grados]");
                                Console.ReadKey();


                            }
                            else if (h3t2 > h3t1)
                            {
                                Console.WriteLine(" Advertencia:La temperarutra mínima no puede ser mayor a la máxima, vuelva a progrmar");
                                Console.ReadKey();
                            }


                           int h3tp = (h3t1 + h3t2) / 2;
                            //Resumen de temperatura
                            Console.WriteLine("RESUMEN PROGRAMACION INGRESADA:");
                            Console.WriteLine("Temp. Max: " + h3t1 + " grados Celsius");
                            Console.WriteLine("Temp. Mix: " + h3t2 + " grados Celsius");
                            Console.WriteLine("Temp. Promedio: " + h3tp + " grados Celsius" + "\n");



                            Console.WriteLine("Temperatura en tiempo real de habitación: " + t3 + " grados celcius" + "\n");
                            if (Convert.ToInt32(t3) > h3t2 || Convert.ToInt32(t3) < h3t1)
                            {
                                Console.WriteLine("Status: Encendido");
                                Console.WriteLine("Sistema de calefacción operando para regular temperatura");
                                Console.ReadKey();
                            }
                            else
                                Console.WriteLine("Temperatura dentro de parametro: calefacción en stanby hasta detectar variación de temperatura" + "\n");
                            Console.ReadKey();

                            break;

                        case (4):

                            Console.WriteLine("Saliendo del Sistema. Gracias por usar el módulo de calefacción");
                            Console.ReadKey();

                            break;


                    }

                    break;



                case 3:
                    //Modulo de Iluminación
                    Console.WriteLine("Bienvenido al Sistema de control de Iluminación");


                    Console.WriteLine("Status Sistema:"+"\n");


                    Console.WriteLine("Master Bedroom");
                    Random rl1 = new Random();
                    int l1 = rl1.Next(0, 5);

                    if (l1 == 0)
                    {
                        Console.WriteLine("Sensor: Movimiento en habitación");
                        Console.WriteLine("ILUMINACION: ON"+"\n");
                        
                    }
                    else
                    {
                        Console.WriteLine("Sensor: Sin movimiento en habitación");
                        Console.WriteLine("ILUMINACION: OFF"+"\n");
                      
                    }

                    Console.WriteLine("Habitación Secundaria");
         
                    Random rl2 = new Random();
                    int l2 = rl2.Next(0, 5); // Para que la aleatoriedad fuera mayor al momento de definir el estatus de la luz

                    if (l2 == 0)
                    {
                        Console.WriteLine("Sensor: Movimiento en habitación");
                        Console.WriteLine("ILUMINACION: ON"+"\n");
                       
                    }
                    else
                    {
                        Console.WriteLine("Sensor: Sin movimiento en habitación");
                        Console.WriteLine("ILUMINACION: OFF" + "\n");
                        
                    }



                    Console.WriteLine("Sala - Comedor");



                    Random rl3 = new Random();
                    int l3 = rl3.Next(0, 5);

                    if (l3 == 0)
                    {
                        Console.WriteLine("Sensor: Movimiento en habitación");
                        Console.WriteLine("ILUMINACION: ON"+"\n");
                       
                    }
                    else
                    {
                        Console.WriteLine("Sensor: Sin movimiento en habitación");
                        Console.WriteLine("ILUMINACION: OFF" + "\n");
                        
                    }




                    Console.WriteLine("Baño Principal");

                    Random rl5 = new Random();
                    int l5 = rl5.Next(0, 5);

                    if (l5 == 0)
                    {
                        Console.WriteLine("Sensor: Movimiento en habitación");
                        Console.WriteLine("ILUMINACION: ON");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Sensor: Sin movimiento en habitación");
                        Console.WriteLine("ILUMINACION: OFF" + "\n");
                        Console.ReadKey();
                    }

                    break;

                case 4:

                    Console.WriteLine("El sistema se esta cerrando, hasta la próxima");
                    Console.ReadKey();
                    break;

                
        
            }     
        }
    }
}
