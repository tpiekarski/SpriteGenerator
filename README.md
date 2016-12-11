# SpriteGenerator
CLI for generating sprites from multiple fixed-sized images in horizontal or vertical alignment.

## Usage

SpriteGenerator -d *input_directory* -f *output_filename* {-h|-v}

## Arguments

Short | Long | Windows | Additional Parameter | Description
------------ | ------------ | ------------ | ------------ | -------------
-d | --directory | /D | *directory* | Input directory with fixed-sized images in a common format like PNG or JPEG
-f | --file | /F | *file* | Output file name
-h | --horizontal | /H | | Horizontal alignment (default)
-v | --vertical | /V | | Vertical alignment 

---

## TODO
- [ ] Add reasonable exception handling
- [ ] Add output file type
- [ ] Add scaling capabilities
- [ ] Add block alignment with default and custom resolution
