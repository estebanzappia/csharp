Console.Write("Introduce el número del día (1 a 7): ");
int numeroDia = int.Parse(Console.ReadLine()!);

string nombreDia = "";

switch (numeroDia)
{
    case 1:
        nombreDia = "Lunes";
        break;
    case 2:
        nombreDia = "Martes";
        break;
    case 3:
        nombreDia = "Miércoles";
        break;
    case 4:
        nombreDia = "Jueves";
        break;
    case 5:
        nombreDia = "Viernes";
        break;
    case 6:
        nombreDia = "Sábado";
        break;
    case 7:
        nombreDia = "Domingo";
        break;
    default:
        Console.WriteLine("Número inválido.");
        return;
}

switch (numeroDia)
{
    case 6:
    case 7:
        Console.WriteLine($"{nombreDia}: fin de semana.");
        break;
    default:
        Console.WriteLine($"{nombreDia}: día laborable.");
        break;
}