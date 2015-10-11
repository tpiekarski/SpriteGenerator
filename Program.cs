using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using SpriteGenerator.Support;

namespace SpriteGenerator {

  class Program {

    
    const int ERROR_INVALID_ARGUMENTS = 1;

    static int Main(string[] args) {

      if (args.Length == 0) {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("No image directory nor any arguments provieded, aborting.");
        sb.AppendLine("Either provide only one argument for the directory or the following ones:");
        sb.AppendLine(" -d|--d <dir>:\t directory with images");
        sb.AppendLine(" -f|--f <file>:\t sprite file to generate");
        sb.AppendLine(" -h|--h:\t horizontal alignment");
        sb.AppendLine(" -v|--v:\t vertical alignment");

        Console.WriteLine(sb.ToString());

        return ERROR_INVALID_ARGUMENTS;
      }

      Arguments arguments = new Arguments(args);
      string returnMessage;
      int imageProcess;
      Image finalSpriteBitmap; ;

      Sprite sprite = new Sprite();

      imageProcess = sprite.ParseDirectory(arguments.GetDirectoryName(), out returnMessage);
      Console.WriteLine(returnMessage);

      finalSpriteBitmap = sprite.Generate(arguments.GetAlignment());

      Console.WriteLine("Saving generated sprite (" + arguments.GetSpriteFileName() + ").");
      finalSpriteBitmap.Save(arguments.GetSpriteFileName(), ImageFormat.Png);

      return imageProcess;
    }

  }

}
