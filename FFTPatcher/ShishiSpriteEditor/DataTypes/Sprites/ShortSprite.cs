﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace FFTPatcher.SpriteEditor
{
    public class ShortSprite : AbstractSprite
    {
        /*
         * 10M
         * 10W
         * 20M
         * 20W
         * 40M
         * 40W
         * 60M
         * 60W
         * CYOMON1
         * CYOMON2
         * CYOMON3
         * CYOMON4
         * FURAIA
         */

        public override int Height
        {
            get { return 288; }
        }

        public ShortSprite( string name, IList<byte> bytes )
            : base( name, bytes )
        {
        }

        protected override Rectangle PortraitRectangle
        {
            get { return new Rectangle( 80, 256, 48, 32 ); }
        }

        protected override Rectangle ThumbnailRectangle
        {
            get { return new Rectangle( 32, 0, 32, 40 ); }
        }

        protected override void ToBitmapInner( System.Drawing.Bitmap bmp, System.Drawing.Imaging.BitmapData bmd )
        {
            for( int i = 0; (i < Pixels.Count) && (i / Width < Height); i++ )
            {
                bmd.SetPixel( i % Width, i / Width, Pixels[i] );
            }
        }

        public override Image GetThumbnail()
        {
            Bitmap result = new Bitmap( 80, 48, PixelFormat.Format24bppRgb );

            using( Bitmap portrait = new Bitmap( 48, 32, PixelFormat.Format8bppIndexed ) )
            using( Bitmap wholeImage = ToBitmap() )
            {
                wholeImage.CopyRectangleToPointNonIndexed(
                    ThumbnailRectangle,
                    result,
                    new Point( (48 - ThumbnailRectangle.Width) / 2, (48 - ThumbnailRectangle.Height) / 2 ),
                    Palettes[0],
                    false );

                ColorPalette palette2 = portrait.Palette;
                FixupColorPalette( palette2 );
                portrait.Palette = palette2;
                wholeImage.CopyRectangleToPoint( PortraitRectangle, portrait, Point.Empty, Palettes[8], false );
                portrait.RotateFlip( RotateFlipType.Rotate270FlipNone );

                portrait.CopyRectangleToPointNonIndexed( new Rectangle( 0, 0, 32, 48 ), result, new Point( 48, 0 ), Palettes[8], false );
            }

            return result;
        }

        protected override IList<byte> BuildPixels( IList<byte> bytes, IList<byte>[] extraBytes )
        {
            byte[] result = new byte[36864 * 2];
            for( int i = 0; i < 36864; i++ )
            {
                result[i * 2] = bytes[i].GetLowerNibble();
                result[i * 2 + 1] = bytes[i].GetUpperNibble();
            }

            return result;
        }

        public override IList<byte[]> ToByteArrays()
        {
            List<byte> ourResult = new List<byte>( 37377 );
            foreach ( Palette p in Palettes )
            {
                ourResult.AddRange( p.ToByteArray() );
            }

            for( int i = 0; i < Pixels.Count / 2; i++ )
            {
                ourResult.Add( (byte)( ( Pixels[2 * i + 1] << 4 ) | ( Pixels[2 * i] & 0x0F ) ) );
            }

            if( ourResult.Count < OriginalSize )
            {
                ourResult.AddRange( new byte[OriginalSize - ourResult.Count] );
            }

            return new byte[][] { ourResult.ToArray() };
        }
    }
}