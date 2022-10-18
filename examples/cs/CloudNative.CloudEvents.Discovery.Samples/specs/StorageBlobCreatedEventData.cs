/*
 * Schema of Azure Storage events published to Azure Event Grid
 *
 * Describes the schema of the Azure Storage events published to Azure Event Grid. This corresponds to the Data property of an EventGridEvent.
 *
 * The version of the OpenAPI document: 2018-01-01
 * 
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace Microsoft.Storage
{
    /// <summary>
    /// Schema of the Data property of an EventGridEvent for a Microsoft.Storage.BlobCreated event.
    /// </summary>
    [DataContract]
    public partial class StorageBlobCreatedEventData :  IEquatable<StorageBlobCreatedEventData>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StorageBlobCreatedEventData" /> class.
        /// </summary>
        /// <param name="api">The name of the API/operation that triggered this event..</param>
        /// <param name="clientRequestId">A request id provided by the client of the storage API operation that triggered this event..</param>
        /// <param name="requestId">The request id generated by the Storage service for the storage API operation that triggered this event..</param>
        /// <param name="eTag">The etag of the blob at the time this event was triggered..</param>
        /// <param name="contentType">The content type of the blob. This is the same as what would be returned in the Content-Type header from the blob..</param>
        /// <param name="contentLength">The size of the blob in bytes. This is the same as what would be returned in the Content-Length header from the blob..</param>
        /// <param name="contentOffset">The offset of the blob in bytes..</param>
        /// <param name="blobType">The type of blob..</param>
        /// <param name="url">The path to the blob..</param>
        /// <param name="sequencer">An opaque string value representing the logical sequence of events for any particular blob name. Users can use standard string comparison to understand the relative sequence of two events on the same blob name..</param>
        /// <param name="identity">The identity of the requester that triggered this event..</param>
        /// <param name="storageDiagnostics">For service use only. Diagnostic data occasionally included by the Azure Storage service. This property should be ignored by event consumers..</param>
        public StorageBlobCreatedEventData(string api = default(string), string clientRequestId = default(string), string requestId = default(string), string eTag = default(string), string contentType = default(string), long contentLength = default(long), long contentOffset = default(long), string blobType = default(string), string url = default(string), string sequencer = default(string), string identity = default(string), Object storageDiagnostics = default(Object))
        {
            this.Api = api;
            this.ClientRequestId = clientRequestId;
            this.RequestId = requestId;
            this.ETag = eTag;
            this.ContentType = contentType;
            this.ContentLength = contentLength;
            this.ContentOffset = contentOffset;
            this.BlobType = blobType;
            this.Url = url;
            this.Sequencer = sequencer;
            this.Identity = identity;
            this.StorageDiagnostics = storageDiagnostics;
        }

        /// <summary>
        /// The name of the API/operation that triggered this event.
        /// </summary>
        /// <value>The name of the API/operation that triggered this event.</value>
        [DataMember(Name="api", EmitDefaultValue=false)]
        public string Api { get; set; }

        /// <summary>
        /// A request id provided by the client of the storage API operation that triggered this event.
        /// </summary>
        /// <value>A request id provided by the client of the storage API operation that triggered this event.</value>
        [DataMember(Name="clientRequestId", EmitDefaultValue=false)]
        public string ClientRequestId { get; set; }

        /// <summary>
        /// The request id generated by the Storage service for the storage API operation that triggered this event.
        /// </summary>
        /// <value>The request id generated by the Storage service for the storage API operation that triggered this event.</value>
        [DataMember(Name="requestId", EmitDefaultValue=false)]
        public string RequestId { get; set; }

        /// <summary>
        /// The etag of the blob at the time this event was triggered.
        /// </summary>
        /// <value>The etag of the blob at the time this event was triggered.</value>
        [DataMember(Name="eTag", EmitDefaultValue=false)]
        public string ETag { get; set; }

        /// <summary>
        /// The content type of the blob. This is the same as what would be returned in the Content-Type header from the blob.
        /// </summary>
        /// <value>The content type of the blob. This is the same as what would be returned in the Content-Type header from the blob.</value>
        [DataMember(Name="contentType", EmitDefaultValue=false)]
        public string ContentType { get; set; }

        /// <summary>
        /// The size of the blob in bytes. This is the same as what would be returned in the Content-Length header from the blob.
        /// </summary>
        /// <value>The size of the blob in bytes. This is the same as what would be returned in the Content-Length header from the blob.</value>
        [DataMember(Name="contentLength", EmitDefaultValue=false)]
        public long ContentLength { get; set; }

        /// <summary>
        /// The offset of the blob in bytes.
        /// </summary>
        /// <value>The offset of the blob in bytes.</value>
        [DataMember(Name="contentOffset", EmitDefaultValue=false)]
        public long ContentOffset { get; set; }

        /// <summary>
        /// The type of blob.
        /// </summary>
        /// <value>The type of blob.</value>
        [DataMember(Name="blobType", EmitDefaultValue=false)]
        public string BlobType { get; set; }

        /// <summary>
        /// The path to the blob.
        /// </summary>
        /// <value>The path to the blob.</value>
        [DataMember(Name="url", EmitDefaultValue=false)]
        public string Url { get; set; }

        /// <summary>
        /// An opaque string value representing the logical sequence of events for any particular blob name. Users can use standard string comparison to understand the relative sequence of two events on the same blob name.
        /// </summary>
        /// <value>An opaque string value representing the logical sequence of events for any particular blob name. Users can use standard string comparison to understand the relative sequence of two events on the same blob name.</value>
        [DataMember(Name="sequencer", EmitDefaultValue=false)]
        public string Sequencer { get; set; }

        /// <summary>
        /// The identity of the requester that triggered this event.
        /// </summary>
        /// <value>The identity of the requester that triggered this event.</value>
        [DataMember(Name="identity", EmitDefaultValue=false)]
        public string Identity { get; set; }

        /// <summary>
        /// For service use only. Diagnostic data occasionally included by the Azure Storage service. This property should be ignored by event consumers.
        /// </summary>
        /// <value>For service use only. Diagnostic data occasionally included by the Azure Storage service. This property should be ignored by event consumers.</value>
        [DataMember(Name="storageDiagnostics", EmitDefaultValue=false)]
        public Object StorageDiagnostics { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class StorageBlobCreatedEventData {\n");
            sb.Append("  Api: ").Append(Api).Append("\n");
            sb.Append("  ClientRequestId: ").Append(ClientRequestId).Append("\n");
            sb.Append("  RequestId: ").Append(RequestId).Append("\n");
            sb.Append("  ETag: ").Append(ETag).Append("\n");
            sb.Append("  ContentType: ").Append(ContentType).Append("\n");
            sb.Append("  ContentLength: ").Append(ContentLength).Append("\n");
            sb.Append("  ContentOffset: ").Append(ContentOffset).Append("\n");
            sb.Append("  BlobType: ").Append(BlobType).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
            sb.Append("  Sequencer: ").Append(Sequencer).Append("\n");
            sb.Append("  Identity: ").Append(Identity).Append("\n");
            sb.Append("  StorageDiagnostics: ").Append(StorageDiagnostics).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as StorageBlobCreatedEventData);
        }

        /// <summary>
        /// Returns true if StorageBlobCreatedEventData instances are equal
        /// </summary>
        /// <param name="input">Instance of StorageBlobCreatedEventData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(StorageBlobCreatedEventData input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Api == input.Api ||
                    (this.Api != null &&
                    this.Api.Equals(input.Api))
                ) && 
                (
                    this.ClientRequestId == input.ClientRequestId ||
                    (this.ClientRequestId != null &&
                    this.ClientRequestId.Equals(input.ClientRequestId))
                ) && 
                (
                    this.RequestId == input.RequestId ||
                    (this.RequestId != null &&
                    this.RequestId.Equals(input.RequestId))
                ) && 
                (
                    this.ETag == input.ETag ||
                    (this.ETag != null &&
                    this.ETag.Equals(input.ETag))
                ) && 
                (
                    this.ContentType == input.ContentType ||
                    (this.ContentType != null &&
                    this.ContentType.Equals(input.ContentType))
                ) && 
                (
                    this.ContentLength == input.ContentLength ||
                    (this.ContentLength != null &&
                    this.ContentLength.Equals(input.ContentLength))
                ) && 
                (
                    this.ContentOffset == input.ContentOffset ||
                    (this.ContentOffset != null &&
                    this.ContentOffset.Equals(input.ContentOffset))
                ) && 
                (
                    this.BlobType == input.BlobType ||
                    (this.BlobType != null &&
                    this.BlobType.Equals(input.BlobType))
                ) && 
                (
                    this.Url == input.Url ||
                    (this.Url != null &&
                    this.Url.Equals(input.Url))
                ) && 
                (
                    this.Sequencer == input.Sequencer ||
                    (this.Sequencer != null &&
                    this.Sequencer.Equals(input.Sequencer))
                ) && 
                (
                    this.Identity == input.Identity ||
                    (this.Identity != null &&
                    this.Identity.Equals(input.Identity))
                ) && 
                (
                    this.StorageDiagnostics == input.StorageDiagnostics ||
                    (this.StorageDiagnostics != null &&
                    this.StorageDiagnostics.Equals(input.StorageDiagnostics))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Api != null)
                    hashCode = hashCode * 59 + this.Api.GetHashCode();
                if (this.ClientRequestId != null)
                    hashCode = hashCode * 59 + this.ClientRequestId.GetHashCode();
                if (this.RequestId != null)
                    hashCode = hashCode * 59 + this.RequestId.GetHashCode();
                if (this.ETag != null)
                    hashCode = hashCode * 59 + this.ETag.GetHashCode();
                if (this.ContentType != null)
                    hashCode = hashCode * 59 + this.ContentType.GetHashCode();
                if (this.ContentLength != null)
                    hashCode = hashCode * 59 + this.ContentLength.GetHashCode();
                if (this.ContentOffset != null)
                    hashCode = hashCode * 59 + this.ContentOffset.GetHashCode();
                if (this.BlobType != null)
                    hashCode = hashCode * 59 + this.BlobType.GetHashCode();
                if (this.Url != null)
                    hashCode = hashCode * 59 + this.Url.GetHashCode();
                if (this.Sequencer != null)
                    hashCode = hashCode * 59 + this.Sequencer.GetHashCode();
                if (this.Identity != null)
                    hashCode = hashCode * 59 + this.Identity.GetHashCode();
                if (this.StorageDiagnostics != null)
                    hashCode = hashCode * 59 + this.StorageDiagnostics.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
