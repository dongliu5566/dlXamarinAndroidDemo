using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using static Java.IO.OutputStream;
using static Java.IO.ByteArrayOutputStream;
using static Java.IO.InputStream;
using static Java.IO.PushbackInputStream;
using static Java.IO.ByteArrayInputStream;
using Java.IO;

using static Java.IO.IOException;
using static Java.Nio.ByteBuffer;

namespace test.encrypt.base64
{
    public abstract class CharacterDecoder
    {
        /**
    * Return the number of bytes per atom of decoding
    */
        abstract protected int bytesPerAtom();

        /**
         * Return the maximum number of bytes that can be encoded per line
         */
        abstract protected int bytesPerLine();

        /**
         * decode the beginning of the buffer, by default this is a NOP.
         */
        protected void decodeBufferPrefix(PushbackInputStream aStream, OutputStream bStream)
        {
            // throw IOException();
        }

        /**
         * decode the buffer suffix, again by default it is a NOP.
         */
        protected void decodeBufferSuffix(PushbackInputStream aStream,
                                          OutputStream bStream)
        {
            //   throws IOException
        }

        /**
         * 103 * This method should return, if it knows, the number of bytes 104 *
         * that will be decoded. Many formats such as uuencoding provide 105 * this
         * information. By default we return the maximum bytes that 106 * could have
         * been encoded on the line. 107
         */
        protected int decodeLinePrefix(PushbackInputStream aStream,
                                       OutputStream bStream)
        {
            //  throws IOException
            return (bytesPerLine());
        }

        /**
         * 113 * This method post processes the line, if there are error detection
         * 114 * or correction codes in a line, they are generally processed by 115
         * * this method. The simplest version of this method looks for the 116 *
         * (newline) character. 117
         */
        protected void decodeLineSuffix(PushbackInputStream aStream,
                                        OutputStream bStream)
        {
            // throws IOException
        }

        /**
         * 121 * This method does an actual decode. It takes the decoded bytes and
         * 122 * writes them to the OutputStream. The integer <i>l</i> tells the 123
         * * method how many bytes are required. This is always <= bytesPerAtom().
         * 124
         */
        protected void decodeAtom(PushbackInputStream aStream,
                                  OutputStream bStream, int l)
        {
            //throws IOException
            //  throw new CEStreamExhausted();
        }

    }
}