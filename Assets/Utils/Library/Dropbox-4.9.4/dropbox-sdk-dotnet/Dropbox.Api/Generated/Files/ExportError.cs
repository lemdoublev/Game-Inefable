// <auto-generated>
// Auto-generated by StoneAPI, do not modify.
// </auto-generated>

namespace Dropbox.Api.Files
{
    using sys = System;
    using col = System.Collections.Generic;
    using re = System.Text.RegularExpressions;

    using enc = Dropbox.Api.Stone;

    /// <summary>
    /// <para>The export error object</para>
    /// </summary>
    public class ExportError
    {
        #pragma warning disable 108

        /// <summary>
        /// <para>The encoder instance.</para>
        /// </summary>
        internal static enc.StructEncoder<ExportError> Encoder = new ExportErrorEncoder();

        /// <summary>
        /// <para>The decoder instance.</para>
        /// </summary>
        internal static enc.StructDecoder<ExportError> Decoder = new ExportErrorDecoder();

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="ExportError" /> class.</para>
        /// </summary>
        public ExportError()
        {
        }

        /// <summary>
        /// <para>Gets a value indicating whether this instance is Path</para>
        /// </summary>
        public bool IsPath
        {
            get
            {
                return this is Path;
            }
        }

        /// <summary>
        /// <para>Gets this instance as a Path, or <c>null</c>.</para>
        /// </summary>
        public Path AsPath
        {
            get
            {
                return this as Path;
            }
        }

        /// <summary>
        /// <para>Gets a value indicating whether this instance is NonExportable</para>
        /// </summary>
        public bool IsNonExportable
        {
            get
            {
                return this is NonExportable;
            }
        }

        /// <summary>
        /// <para>Gets this instance as a NonExportable, or <c>null</c>.</para>
        /// </summary>
        public NonExportable AsNonExportable
        {
            get
            {
                return this as NonExportable;
            }
        }

        /// <summary>
        /// <para>Gets a value indicating whether this instance is Other</para>
        /// </summary>
        public bool IsOther
        {
            get
            {
                return this is Other;
            }
        }

        /// <summary>
        /// <para>Gets this instance as a Other, or <c>null</c>.</para>
        /// </summary>
        public Other AsOther
        {
            get
            {
                return this as Other;
            }
        }

        #region Encoder class

        /// <summary>
        /// <para>Encoder for  <see cref="ExportError" />.</para>
        /// </summary>
        private class ExportErrorEncoder : enc.StructEncoder<ExportError>
        {
            /// <summary>
            /// <para>Encode fields of given value.</para>
            /// </summary>
            /// <param name="value">The value.</param>
            /// <param name="writer">The writer.</param>
            public override void EncodeFields(ExportError value, enc.IJsonWriter writer)
            {
                if (value is Path)
                {
                    WriteProperty(".tag", "path", writer, enc.StringEncoder.Instance);
                    Path.Encoder.EncodeFields((Path)value, writer);
                    return;
                }
                if (value is NonExportable)
                {
                    WriteProperty(".tag", "non_exportable", writer, enc.StringEncoder.Instance);
                    NonExportable.Encoder.EncodeFields((NonExportable)value, writer);
                    return;
                }
                if (value is Other)
                {
                    WriteProperty(".tag", "other", writer, enc.StringEncoder.Instance);
                    Other.Encoder.EncodeFields((Other)value, writer);
                    return;
                }
                throw new sys.InvalidOperationException();
            }
        }

        #endregion

        #region Decoder class

        /// <summary>
        /// <para>Decoder for  <see cref="ExportError" />.</para>
        /// </summary>
        private class ExportErrorDecoder : enc.UnionDecoder<ExportError>
        {
            /// <summary>
            /// <para>Create a new instance of type <see cref="ExportError" />.</para>
            /// </summary>
            /// <returns>The struct instance.</returns>
            protected override ExportError Create()
            {
                return new ExportError();
            }

            /// <summary>
            /// <para>Decode based on given tag.</para>
            /// </summary>
            /// <param name="tag">The tag.</param>
            /// <param name="reader">The json reader.</param>
            /// <returns>The decoded object.</returns>
            protected override ExportError Decode(string tag, enc.IJsonReader reader)
            {
                switch (tag)
                {
                    case "path":
                        return Path.Decoder.DecodeFields(reader);
                    case "non_exportable":
                        return NonExportable.Decoder.DecodeFields(reader);
                    default:
                        return Other.Decoder.DecodeFields(reader);
                }
            }
        }

        #endregion

        /// <summary>
        /// <para>The path object</para>
        /// </summary>
        public sealed class Path : ExportError
        {
            #pragma warning disable 108

            /// <summary>
            /// <para>The encoder instance.</para>
            /// </summary>
            internal static enc.StructEncoder<Path> Encoder = new PathEncoder();

            /// <summary>
            /// <para>The decoder instance.</para>
            /// </summary>
            internal static enc.StructDecoder<Path> Decoder = new PathDecoder();

            /// <summary>
            /// <para>Initializes a new instance of the <see cref="Path" /> class.</para>
            /// </summary>
            /// <param name="value">The value</param>
            public Path(LookupError value)
            {
                this.Value = value;
            }
            /// <summary>
            /// <para>Initializes a new instance of the <see cref="Path" /> class.</para>
            /// </summary>
            private Path()
            {
            }

            /// <summary>
            /// <para>Gets the value of this instance.</para>
            /// </summary>
            public LookupError Value { get; private set; }

            #region Encoder class

            /// <summary>
            /// <para>Encoder for  <see cref="Path" />.</para>
            /// </summary>
            private class PathEncoder : enc.StructEncoder<Path>
            {
                /// <summary>
                /// <para>Encode fields of given value.</para>
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="writer">The writer.</param>
                public override void EncodeFields(Path value, enc.IJsonWriter writer)
                {
                    WriteProperty("path", value.Value, writer, global::Dropbox.Api.Files.LookupError.Encoder);
                }
            }

            #endregion

            #region Decoder class

            /// <summary>
            /// <para>Decoder for  <see cref="Path" />.</para>
            /// </summary>
            private class PathDecoder : enc.StructDecoder<Path>
            {
                /// <summary>
                /// <para>Create a new instance of type <see cref="Path" />.</para>
                /// </summary>
                /// <returns>The struct instance.</returns>
                protected override Path Create()
                {
                    return new Path();
                }

                /// <summary>
                /// <para>Set given field.</para>
                /// </summary>
                /// <param name="value">The field value.</param>
                /// <param name="fieldName">The field name.</param>
                /// <param name="reader">The json reader.</param>
                protected override void SetField(Path value, string fieldName, enc.IJsonReader reader)
                {
                    switch (fieldName)
                    {
                        case "path":
                            value.Value = global::Dropbox.Api.Files.LookupError.Decoder.Decode(reader);
                            break;
                        default:
                            reader.Skip();
                            break;
                    }
                }
            }

            #endregion
        }

        /// <summary>
        /// <para>This file type cannot be exported. Use <see
        /// cref="Dropbox.Api.Files.Routes.FilesUserRoutes.DownloadAsync" /> instead.</para>
        /// </summary>
        public sealed class NonExportable : ExportError
        {
            #pragma warning disable 108

            /// <summary>
            /// <para>The encoder instance.</para>
            /// </summary>
            internal static enc.StructEncoder<NonExportable> Encoder = new NonExportableEncoder();

            /// <summary>
            /// <para>The decoder instance.</para>
            /// </summary>
            internal static enc.StructDecoder<NonExportable> Decoder = new NonExportableDecoder();

            /// <summary>
            /// <para>Initializes a new instance of the <see cref="NonExportable" />
            /// class.</para>
            /// </summary>
            private NonExportable()
            {
            }

            /// <summary>
            /// <para>A singleton instance of NonExportable</para>
            /// </summary>
            public static readonly NonExportable Instance = new NonExportable();

            #region Encoder class

            /// <summary>
            /// <para>Encoder for  <see cref="NonExportable" />.</para>
            /// </summary>
            private class NonExportableEncoder : enc.StructEncoder<NonExportable>
            {
                /// <summary>
                /// <para>Encode fields of given value.</para>
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="writer">The writer.</param>
                public override void EncodeFields(NonExportable value, enc.IJsonWriter writer)
                {
                }
            }

            #endregion

            #region Decoder class

            /// <summary>
            /// <para>Decoder for  <see cref="NonExportable" />.</para>
            /// </summary>
            private class NonExportableDecoder : enc.StructDecoder<NonExportable>
            {
                /// <summary>
                /// <para>Create a new instance of type <see cref="NonExportable" />.</para>
                /// </summary>
                /// <returns>The struct instance.</returns>
                protected override NonExportable Create()
                {
                    return NonExportable.Instance;
                }

            }

            #endregion
        }

        /// <summary>
        /// <para>The other object</para>
        /// </summary>
        public sealed class Other : ExportError
        {
            #pragma warning disable 108

            /// <summary>
            /// <para>The encoder instance.</para>
            /// </summary>
            internal static enc.StructEncoder<Other> Encoder = new OtherEncoder();

            /// <summary>
            /// <para>The decoder instance.</para>
            /// </summary>
            internal static enc.StructDecoder<Other> Decoder = new OtherDecoder();

            /// <summary>
            /// <para>Initializes a new instance of the <see cref="Other" /> class.</para>
            /// </summary>
            private Other()
            {
            }

            /// <summary>
            /// <para>A singleton instance of Other</para>
            /// </summary>
            public static readonly Other Instance = new Other();

            #region Encoder class

            /// <summary>
            /// <para>Encoder for  <see cref="Other" />.</para>
            /// </summary>
            private class OtherEncoder : enc.StructEncoder<Other>
            {
                /// <summary>
                /// <para>Encode fields of given value.</para>
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="writer">The writer.</param>
                public override void EncodeFields(Other value, enc.IJsonWriter writer)
                {
                }
            }

            #endregion

            #region Decoder class

            /// <summary>
            /// <para>Decoder for  <see cref="Other" />.</para>
            /// </summary>
            private class OtherDecoder : enc.StructDecoder<Other>
            {
                /// <summary>
                /// <para>Create a new instance of type <see cref="Other" />.</para>
                /// </summary>
                /// <returns>The struct instance.</returns>
                protected override Other Create()
                {
                    return Other.Instance;
                }

            }

            #endregion
        }
    }
}