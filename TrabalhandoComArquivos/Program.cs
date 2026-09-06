Console.WriteLine("Hello, World!");

//string caminho = "/Users/Matheus/Documents/";

// Pega a pasta base do usuário atual (No Mac: /Users/Usuario | No Win: C:\Users\Usuario)
//string pastaUsuario = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
//System.Console.WriteLine(pastaUsuario);

// Junta com a subpasta desejada e o arquivo
// string caminhoCompletoOrigem = Path.Combine(pastaUsuario, "Curso C#", "TrabalhandoComArquivos", "teste.txt");
//string caminhoCompletoDestino = Path.Combine(pastaUsuario, "Curso C#", "TrabalhandoComArquivos", "testeDestino.txt");

string _caminhoCompletoOrigem = "/Users/Matheus/Curso C#/TrabalhandoComArquivos/teste.txt";
string _caminhoCompletoDestino = "/Users/Matheus/Curso C#/TrabalhandoComArquivos/temp/marcelo.txt";

// string _caminhoCompletoOrigem = @"teste.txt";
// string _caminhoCompletoDestino = @"temp/testeDestino.txt";


var fileInfo = new FileInfo(_caminhoCompletoOrigem);
try
{
    fileInfo.CopyTo(_caminhoCompletoDestino);
    System.Console.WriteLine(new FileInfo(_caminhoCompletoDestino).Name);
    System.Console.WriteLine("Arquivo copiado!");
        
}
catch (IOException ex)
{
        //throw new IOException(ex.Message);

    System.Console.WriteLine(ex.Message);
    System.Console.WriteLine("Arquivo nao copiado!");
}
return;









