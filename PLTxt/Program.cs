using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.RegularExpressions;
using System.IO;


class Program
{
    static void Main(string[] args)
    {

        //string filePath = "C:\\Users\\digis\\OneDrive\\Documents\\Rojas Valdes Edgar Alejandro\\Rojas Valdes Edgar Alejandro\\TXT\\Txt1.txt";
        string filePath = "C:\\Users\\digis\\OneDrive\\Documents\\Rojas Valdes Edgar Alejandro\\Rojas Valdes Edgar Alejandro\\TXT\\Txt2.txt";
        try
        {

            string[] lines = File.ReadAllLines(filePath);
            Console.WriteLine("UserName Nombre ApellidoPaterno ApellidoMaterno Email Password Sexo Telefono Celular FechaNacimiento CURP IdRol");
            

            foreach (string textToSplit in lines)
            {
                string[] parts = textToSplit.Split('|');

                parts = parts.Skip(1).ToArray();

                string VC = ValidarFilas(parts);

                
                Console.Write(string.Join(" ", parts));
                Console.WriteLine(" ");
                Console.WriteLine(VC);
                Console.WriteLine(" ");

            }
        }


        catch (Exception e)
        {
            Console.WriteLine("El archivo no se pudo leer: " + e.Message);
        }
    }

    public static string ValidarFilas(string[] parts)
    {

        string error = "";

        //Console.WriteLine(parts[0]);//Username YA
        if (!Regex.IsMatch(parts[0], @"^[a-zA-Z0-9]+$"))
        {
            //Console.WriteLine(parts[0]);
            error = error + "Error Aqui Username :" + parts[0] + "| ";


        }

        //Console.WriteLine(parts[1]);//Nombre YA
        if (!Regex.IsMatch(parts[1], @"^[a-zA-Z]+$"))
        {
            //Console.WriteLine(parts[1]);
            error = error + "Error Aqui Nombre: " + parts[1] + "| ";

        }

        //Console.WriteLine(parts[2]);//ApellidoPaterno YA
        if (!Regex.IsMatch(parts[2], @"^[a-zA-Z]+$"))
        {
            //Console.WriteLine(parts[2]);
            error = error + "Error Aqui ApellidoPaterno: " + parts[2] + "| ";

        }

        //Console.WriteLine(parts[3]);//ApellidoMaterno YA
        if (!Regex.IsMatch(parts[3], @"^[a-zA-Z]+$"))
        {
            //Console.WriteLine(parts[3]);
            error = error + "Error Aqui ApellidoMaterno: " + parts[3] + "| ";

        }

        //Console.WriteLine(parts[4]);//Email YA
        if (!Regex.IsMatch(parts[4], @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
        {
            //Console.WriteLine(parts[4]);
            error = error + "Error Aqui Email: " + parts[4] + "| ";

        }

        //Console.WriteLine(parts[5]);//Password Ya?? Checar Expresion Reuglar
        if (!Regex.IsMatch(parts[5], @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+\-=\[\]{};':\\|,.<>\/?]).{8,}$"))
        {
            //Console.WriteLine(parts[5]);
            error = error + "Error Aqui Password: " + parts[5] + "| ";

        }

        //Console.WriteLine(parts[6]);//Sexo YA
        if (!Regex.IsMatch(parts[6], @"^[MF]$"))
        {
            //Console.WriteLine(parts[6]);
            error = error + "Error Aqui Sexo: " + parts[6] + "| ";

        }

        //Console.WriteLine(parts[7]);//Telefono YA
        if (!Regex.IsMatch(parts[7], @"^\d+$"))
        {
            //Console.WriteLine(parts[7]);
            error = error + "Error Aqui Telefono: " + parts[7] + "| ";

        }

        //Console.WriteLine(parts[8]);//Celular YA
        if (!Regex.IsMatch(parts[8], @"^\d+$"))
        {
            //Console.WriteLine(parts[8]);
            error = error + "Error Aqui Celular: " + parts[8] + "| ";

        }

        //Console.WriteLine(parts[9]);//FechaNacimiento Ya
        if (!Regex.IsMatch(parts[9], @"^\d{4}-\d{2}-\d{2}$"))
        {
            //Console.WriteLine(parts[9]);
            error = error + "Error Aqui FechaNacimiento: " + parts[9] + "| ";

        }

        //Console.WriteLine(parts[10]);//Curp YA
        if (!Regex.IsMatch(parts[10], @"^[A-Z]{4}\d{6}[HM][A-Z]{5}[0-9A-Z]\d$"))
        {
            //Console.WriteLine(parts[10]);
            error = error + "Error Aqui Curp: " + parts[10] + "| ";

        }


        //Console.WriteLine(parts[11]);//IdRol
        if (!Regex.IsMatch(parts[11], @"^[1-6]$"))
        {
            //Console.WriteLine(parts[11]);
            error = error + "Error Aqui IdRol: " + parts[11] + "| ";

        }

        return error;
    }
}


/*
 *  linealeida== parts
 *  
 *  
 * 
 * 1.- string[].linealeida = linea.split("|");
 * 2.- string VC = ValidarFilas(linealeida);
 * 3.- cw(linealeida[0]);
 * 
 * Public Static string VC(string[] liealeida){
 * string error= "";
 * if(Regex.IsMatch(linealeida[0], "Expresion R")){
 * error = error + "Error Aqui" + linealeida[0] + "|";
 * 
 * }
 * }
 */