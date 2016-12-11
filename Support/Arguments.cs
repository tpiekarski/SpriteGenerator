using System;
using System.Collections.Generic;

namespace SpriteGenerator.Support {

  class Arguments {

    const string DEFAULT_SPRITE_FILENAME = "sprite.png";
    const string DEFAULT_SPRITE_ALIGNMENT = "Horizontal";

    private string directoryName { get; }
    private string spriteFileName { get; }
    private string alignment { get; }

    public Arguments(string[] arguments) {

      // Default values
      spriteFileName = DEFAULT_SPRITE_FILENAME;
      alignment = DEFAULT_SPRITE_ALIGNMENT;

      if (arguments.Length == 1) {
        directoryName = arguments.GetValue(0).ToString();

        return;
      }

      for (int n = 0; n < arguments.Length; n++) {

        switch (arguments.GetValue(n).ToString()) {

          case "-d":
          case "--directory":

            directoryName = arguments.GetValue(n + 1).ToString();
            break;

          case "-f":
          case "--file":

            spriteFileName = arguments.GetValue(n + 1).ToString();
            break;

          case "-h":
          case "--horizontal":

            alignment = "Horizontal";
            break;

          case "-v":
          case "--vertical":

            alignment = "Vertical";
            break;
        }

      }

    }

    public string GetAlignment() {
      return alignment;
    }

    public string GetDirectoryName() {
      return directoryName;
    }

    public string GetSpriteFileName() {
      return spriteFileName;
    }

  }

}
