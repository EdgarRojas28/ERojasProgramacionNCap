using System.Linq;

class Program
{
    static void Main(string[] args)
    {

        //string filePath = "C:\\Users\\digis\\OneDrive\\Documents\\Rojas Valdes Edgar Alejandro\\Rojas Valdes Edgar Alejandro\\TXT\\Txt1.txt";
        string filePath = "C:\\Users\\digis\\OneDrive\\Documents\\Rojas Valdes Edgar Alejandro\\Rojas Valdes Edgar Alejandro\\TXT\\Txt2.txt";
        try
        {
            
            string[] lines = File.ReadAllLines(filePath);

            foreach (string textToSplit in lines) 
            {                
                string[] parts = textToSplit.Split('|');                
                parts = parts.Skip(1).ToArray();               
                Console.WriteLine(string.Join(" ", parts));
            }
        }

        catch (Exception e)
        {
            Console.WriteLine("El archivo no se pudo leer: " + e.Message);
        }
    }
}