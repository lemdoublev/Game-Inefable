// <auto-generated>
// Auto-generated by StoneAPI, do not modify.
// </auto-generated>

namespace Dropbox.Api.FileRequests
{
    using sys = System;
    using col = System.Collections.Generic;
    using re = System.Text.RegularExpressions;

    using enc = Dropbox.Api.Stone;

    /// <summary>
    /// <para>Arguments for <see
    /// cref="Dropbox.Api.FileRequests.Routes.FileRequestsUserRoutes.ListV2Async" />.</para>
    /// </summary>
    public class ListFileRequestsArg
    {
        #pragma warning disable 108

        /// <summary>
        /// <para>The encoder instance.</para>
        /// </summary>
        internal static enc.StructEncoder<ListFileRequestsArg> Encoder = new ListFileRequestsArgEncoder();

        /// <summary>
        /// <para>The decoder instance.</para>
        /// </summary>
        internal static enc.StructDecoder<ListFileRequestsArg> Decoder = new ListFileRequestsArgDecoder();

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="ListFileRequestsArg" />
        /// class.</para>
        /// </summary>
        /// <param name="limit">The maximum number of file requests that should be returned per
        /// request.</param>
        public ListFileRequestsArg(ulong limit = 1000)
        {
            this.Limit = limit;
        }

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="ListFileRequestsArg" />
        /// class.</para>
        /// </summary>
        /// <remarks>This is to construct an instance of the object when
        /// deserializing.</remarks>
        [sys.ComponentModel.EditorBrowsable(sys.ComponentModel.EditorBrowsableState.Never)]
        public ListFileRequestsArg()
        {
            this.Limit = 1000;
        }

        /// <summary>
        /// <para>The maximum number of file requests that should be returned per
        /// request.</para>
        /// </summary>
        public ulong Limit { get; protected set; }

        #region Encoder class

        /// <summary>
        /// <para>Encoder for  <see cref="ListFileRequestsArg" />.</para>
        /// </summary>
        private class ListFileRequestsArgEncoder : enc.StructEncoder<ListFileRequestsArg>
        {
            /// <summary>
            /// <para>Encode fields of given value.</para>
            /// </summary>
            /// <param name="value">The value.</param>
            /// <param name="writer">The writer.</param>
            public override void EncodeFields(ListFileRequestsArg value, enc.IJsonWriter writer)
            {
                WriteProperty("limit", value.Limit, writer, enc.UInt64Encoder.Instance);
            }
        }

        #endregion


        #region Decoder class

        /// <summary>
        /// <para>Decoder for  <see cref="ListFileRequestsArg" />.</para>
        /// </summary>
        private class ListFileRequestsArgDecoder : enc.StructDecoder<ListFileRequestsArg>
        {
            /// <summary>
            /// <para>Create a new instance of type <see cref="ListFileRequestsArg" />.</para>
            /// </summary>
            /// <returns>The struct instance.</returns>
            protected override ListFileRequestsArg Create()
            {
                return new ListFileRequestsArg();
            }

            /// <summary>
            /// <para>Set given field.</para>
            /// </summary>
            /// <param name="value">The field value.</param>
            /// <param name="fieldName">The field name.</param>
            /// <param name="reader">The json reader.</param>
            protected override void SetField(ListFileRequestsArg value, string fieldName, enc.IJsonReader reader)
            {
                switch (fieldName)
                {
                    case "limit":
                        value.Limit = enc.UInt64Decoder.Instance.Decode(reader);
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }
        }

        #endregion
    }
}