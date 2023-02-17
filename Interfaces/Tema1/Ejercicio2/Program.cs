#define frase
string? frase1 = Console.ReadLine();
string? frase2 = Console.ReadLine();
#if frase   
Console.WriteLine("\"{0}\"\t\\{1}\\\r\n{0}\r\n{1}", frase1, frase2);
#else
Console.WriteLine("{0}\t{1}", frase1, frase2);
#endif