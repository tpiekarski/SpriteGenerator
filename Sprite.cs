using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace SpriteGenerator {

  class Sprite {

    private const int ERROR_INVALID_DIRECTORY = 2;
    private const int ERROR_NO_FILES = 3;
    private const int ERROR_NO_IMAGES = 4;

    private const string SPRITE_ALIGNMENT = "Horizontal";

    private List<string> imageFileNames;
    private List<Image> images;

    private Image spriteImage;
    private Size spriteSize;

    public Sprite() {
      images = new List<Image>();
      spriteSize = new Size(0, 0);
    }

    public int ParseDirectory(string imageDirectory, out string returnMessage) {

      if (!Directory.Exists(imageDirectory)) {
        returnMessage = "Directory " + imageDirectory + " does not exist, aborting.";

        return ERROR_INVALID_DIRECTORY;
      }

      string[] filenames = Directory.GetFiles(imageDirectory);

      if (filenames.Length == 0) {
        returnMessage = "Directory " + imageDirectory + " is empty, aborting.";

        return ERROR_NO_FILES;
      }

      imageFileNames = new List<string>(filenames);
      StringBuilder sb = new StringBuilder();
      Image currentImage;

      foreach (string filename in imageFileNames) {
        if (!File.Exists(filename)) {
          sb.AppendLine(filename + " does not exist or can not be accessed, skipping.");
          continue;
        }

        sb.AppendLine("Processing " + filename);
        currentImage = Bitmap.FromFile(filename);

        if (spriteSize.IsEmpty)
          AllocateSize(currentImage.Width, currentImage.Height);

        images.Add(currentImage);
        
      }

      if (images.Count == 0) {
        sb.AppendLine("No image files for generating sprite, aborting");
        returnMessage = sb.ToString();

        return ERROR_NO_IMAGES;
      }

      returnMessage = sb.ToString();
      return 0;

    }

    private void AllocateSize(int width, int height) {
      spriteSize.Width = width;
      spriteSize.Height = height;
    }

    public Image Generate() {

      Size finalSize = spriteSize;

      if (SPRITE_ALIGNMENT == "Horizontal") {
        finalSize.Width = spriteSize.Width * images.Count;
        finalSize.Height = spriteSize.Height;
      }
      else {
        finalSize.Width = spriteSize.Width;
        finalSize.Height = spriteSize.Height * images.Count;
      }


      spriteImage = new Bitmap(finalSize.Width, finalSize.Height);
      Graphics gfx = Graphics.FromImage(spriteImage);

      for (int x = 0, n = 0; x <= finalSize.Width - spriteSize.Width; x += spriteSize.Width, n++) {
        gfx.DrawImage(images[n], x, 0);
      }

      return spriteImage;
    }

  }

}
