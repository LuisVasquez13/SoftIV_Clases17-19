// Programa trabajado segun lo visto en los videos del 17 al 19 de C# en Platzi
// Desarrollo de Software IV

using System.Drawing;
System.Random random = new System.Random(); // Crear una instancia de Random para generar números aleatorios

int totalJugador = 0, totalDealer = 0, num = 0, coins = 0;
string message = "";
string controlOtraCarta = "";
string switchControl = "menu";

while (true) // Ciclo While para repetir el juego
{
    // Menú principal del juego
    Console.WriteLine("\nWelcome al C a s i n o");
    Console.WriteLine("¿Cuántos Coins deseas? \n" +
                       "- Si quieres salir ingresa cero (0) \n" +
                       "Ingresa un valor: ");
    coins = int.Parse(Console.ReadLine());

    if (coins <= 0) // Se cierra el ciclo While
    {
        break;
    }

    // Ciclo For para las rondas del juego
    for (int i = 0; i < coins; i++)
    {
        // Reiniciar variables para la siguiente ronda
        totalJugador = 0;
        totalDealer = 0;
        Console.WriteLine("Siguiente ronda:");
        Console.WriteLine("1. Comenzar\n2. Rendirte");
        // Solicitar al jugador si desea seguir o rendirse
        Console.Write("Escriba '1' para seguir o '2' para rendirte: ");
        switchControl = Console.ReadLine();

        // Estructura switch para manejar las opciones del jugador
        switch (switchControl)
        {
            case "1": // Seguir con la siguiente ronda
                do
                {
                    num = random.Next(1, 12); // Generar un número aleatorio entre 1 y 11
                    totalJugador = totalJugador + num;
                    Console.WriteLine("Toma tu carta, jugador,");
                    Console.WriteLine($"Te salió el número: {num} ");
                    Console.WriteLine("¿Deseas otra carta?"); // Preguntar si desea otra carta
                    controlOtraCarta = Console.ReadLine();

                // Repetir si el jugador quiere otra carta
                } while (controlOtraCarta == "Si" ||
                         controlOtraCarta == "si" ||
                         controlOtraCarta == "yes"); 

                totalDealer = random.Next(14, 23); // Generar un número aleatorio para el dealer entre 14 y 22
                // Muestrar los totales del jugador y del dealer
                Console.WriteLine($"Tu total es {totalJugador}");
                Console.WriteLine($"El dealer tiene {totalDealer}");

                // Regla para ganar : Juntar mas de 15 cartas y menos de 22 y mas que el dealer

                // Determinar el resultado de la ronda
                if (totalJugador > totalDealer && totalJugador < 22) // Ganar al dealer
                {
                    message = "Venciste al dealer, felicidades";
                }
                else if (totalJugador >= 22) // Perder por pasarse de 21
                {
                    message = "Perdiste vs el dealer, te pasaste de 21";
                }
                else if (totalJugador <= totalDealer) // Perder al dealer
                {
                    message = "Perdiste vs el dealer, lo siento";
                }
                else // Condición no válida
                {
                    message = "Condición no válida";
                }
                // Muestra el resultado obtenido
                Console.WriteLine(message);
                break;
            case "2": // Rendirte en la ronda
                i = coins; // Salir del ciclo For
                break;
            default: // Opción no válida
                Console.WriteLine("Valor ingresa no válido en el  C A S I N O");
                break;
        }
    }
}