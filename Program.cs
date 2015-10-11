using System;
using System.Drawing;

namespace SpriteGenerator {

  class Program {

    const int ERROR_INVALID_ARGUMENTS = 1;

    static int Main(string[] args) {

      if (args.Length == 0) {
        Console.WriteLine("No image directory provieded, aborting.");

        return ERROR_INVALID_ARGUMENTS;
      }

      string directoryName = args.GetValue(0).ToString();
      string returnMessage;
      int imageProcess;
      Bitmap finalSpriteBitmap; ;

      Sprite sprite = new Sprite();

      imageProcess = sprite.ParseDirectory(directoryName, out returnMessage);

      finalSpriteBitmap = sprite.Generate();

      Console.WriteLine(returnMessage);
      return imageProcess;

    }

  }

}
