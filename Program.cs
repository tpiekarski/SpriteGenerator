using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace SpriteGenerator {

  class Program {

    const string DEFAULT_SPRITE_FILENAME = "sprite.png";
    const int ERROR_INVALID_ARGUMENTS = 1;

    static int Main(string[] args) {

      if (args.Length == 0) {
        Console.WriteLine("No image directory provieded, aborting.");

        return ERROR_INVALID_ARGUMENTS;
      }

      string directoryName = args.GetValue(0).ToString();
      string returnMessage;
      int imageProcess;
      Image finalSpriteBitmap; ;

      Sprite sprite = new Sprite();

      imageProcess = sprite.ParseDirectory(directoryName, out returnMessage);
      Console.WriteLine(returnMessage);

      finalSpriteBitmap = sprite.Generate();

      Console.WriteLine("Saving generated sprite (" + DEFAULT_SPRITE_FILENAME + ").");
      finalSpriteBitmap.Save(DEFAULT_SPRITE_FILENAME, ImageFormat.Png);

      return imageProcess;
    }

  }

}
