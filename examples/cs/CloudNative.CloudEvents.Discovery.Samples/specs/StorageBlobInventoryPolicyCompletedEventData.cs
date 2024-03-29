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
    /// Schema of the Data property of an EventGridEvent for an Microsoft.Storage.BlobInventoryPolicyCompleted event.
    /// </summary>
    [DataContract]
    public partial class StorageBlobInventoryPolicyCompletedEventData :  IEquatable<StorageBlobInventoryPolicyCompletedEventData>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StorageBlobInventoryPolicyCompletedEventData" /> class.
        /// </summary>
        /// <param name="scheduleDateTime">The time at which inventory policy was scheduled..</param>
        /// <param name="accountName">The account name for which inventory policy is registered..</param>
        /// <param name="ruleName">The rule name for inventory policy..</param>
        /// <param name="policyRunStatus">The status of inventory run, it can be Succeeded/PartiallySucceeded/Failed..</param>
        /// <param name="policyRunStatusMessage">The status message for inventory run..</param>
        /// <param name="policyRunId">The policy run id for inventory run..</param>
        /// <param name="manifestBlobUrl">The blob URL for manifest file for inventory run..</param>
        public StorageBlobInventoryPolicyCompletedEventData(DateTime scheduleDateTime = default(DateTime), string accountName = default(string), string ruleName = default(string), string policyRunStatus = default(string), string policyRunStatusMessage = default(string), string policyRunId = default(string), string manifestBlobUrl = default(string))
        {
            this.ScheduleDateTime = scheduleDateTime;
            this.AccountName = accountName;
            this.RuleName = ruleName;
            this.PolicyRunStatus = policyRunStatus;
            this.PolicyRunStatusMessage = policyRunStatusMessage;
            this.PolicyRunId = policyRunId;
            this.ManifestBlobUrl = manifestBlobUrl;
        }

        /// <summary>
        /// The time at which inventory policy was scheduled.
        /// </summary>
        /// <value>The time at which inventory policy was scheduled.</value>
        [DataMember(Name="scheduleDateTime", EmitDefaultValue=false)]
        public DateTime ScheduleDateTime { get; set; }

        /// <summary>
        /// The account name for which inventory policy is registered.
        /// </summary>
        /// <value>The account name for which inventory policy is registered.</value>
        [DataMember(Name="accountName", EmitDefaultValue=false)]
        public string AccountName { get; set; }

        /// <summary>
        /// The rule name for inventory policy.
        /// </summary>
        /// <value>The rule name for inventory policy.</value>
        [DataMember(Name="ruleName", EmitDefaultValue=false)]
        public string RuleName { get; set; }

        /// <summary>
        /// The status of inventory run, it can be Succeeded/PartiallySucceeded/Failed.
        /// </summary>
        /// <value>The status of inventory run, it can be Succeeded/PartiallySucceeded/Failed.</value>
        [DataMember(Name="policyRunStatus", EmitDefaultValue=false)]
        public string PolicyRunStatus { get; set; }

        /// <summary>
        /// The status message for inventory run.
        /// </summary>
        /// <value>The status message for inventory run.</value>
        [DataMember(Name="policyRunStatusMessage", EmitDefaultValue=false)]
        public string PolicyRunStatusMessage { get; set; }

        /// <summary>
        /// The policy run id for inventory run.
        /// </summary>
        /// <value>The policy run id for inventory run.</value>
        [DataMember(Name="policyRunId", EmitDefaultValue=false)]
        public string PolicyRunId { get; set; }

        /// <summary>
        /// The blob URL for manifest file for inventory run.
        /// </summary>
        /// <value>The blob URL for manifest file for inventory run.</value>
        [DataMember(Name="manifestBlobUrl", EmitDefaultValue=false)]
        public string ManifestBlobUrl { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class StorageBlobInventoryPolicyCompletedEventData {\n");
            sb.Append("  ScheduleDateTime: ").Append(ScheduleDateTime).Append("\n");
            sb.Append("  AccountName: ").Append(AccountName).Append("\n");
            sb.Append("  RuleName: ").Append(RuleName).Append("\n");
            sb.Append("  PolicyRunStatus: ").Append(PolicyRunStatus).Append("\n");
            sb.Append("  PolicyRunStatusMessage: ").Append(PolicyRunStatusMessage).Append("\n");
            sb.Append("  PolicyRunId: ").Append(PolicyRunId).Append("\n");
            sb.Append("  ManifestBlobUrl: ").Append(ManifestBlobUrl).Append("\n");
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
            return this.Equals(input as StorageBlobInventoryPolicyCompletedEventData);
        }

        /// <summary>
        /// Returns true if StorageBlobInventoryPolicyCompletedEventData instances are equal
        /// </summary>
        /// <param name="input">Instance of StorageBlobInventoryPolicyCompletedEventData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(StorageBlobInventoryPolicyCompletedEventData input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ScheduleDateTime == input.ScheduleDateTime ||
                    (this.ScheduleDateTime != null &&
                    this.ScheduleDateTime.Equals(input.ScheduleDateTime))
                ) && 
                (
                    this.AccountName == input.AccountName ||
                    (this.AccountName != null &&
                    this.AccountName.Equals(input.AccountName))
                ) && 
                (
                    this.RuleName == input.RuleName ||
                    (this.RuleName != null &&
                    this.RuleName.Equals(input.RuleName))
                ) && 
                (
                    this.PolicyRunStatus == input.PolicyRunStatus ||
                    (this.PolicyRunStatus != null &&
                    this.PolicyRunStatus.Equals(input.PolicyRunStatus))
                ) && 
                (
                    this.PolicyRunStatusMessage == input.PolicyRunStatusMessage ||
                    (this.PolicyRunStatusMessage != null &&
                    this.PolicyRunStatusMessage.Equals(input.PolicyRunStatusMessage))
                ) && 
                (
                    this.PolicyRunId == input.PolicyRunId ||
                    (this.PolicyRunId != null &&
                    this.PolicyRunId.Equals(input.PolicyRunId))
                ) && 
                (
                    this.ManifestBlobUrl == input.ManifestBlobUrl ||
                    (this.ManifestBlobUrl != null &&
                    this.ManifestBlobUrl.Equals(input.ManifestBlobUrl))
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
                if (this.ScheduleDateTime != null)
                    hashCode = hashCode * 59 + this.ScheduleDateTime.GetHashCode();
                if (this.AccountName != null)
                    hashCode = hashCode * 59 + this.AccountName.GetHashCode();
                if (this.RuleName != null)
                    hashCode = hashCode * 59 + this.RuleName.GetHashCode();
                if (this.PolicyRunStatus != null)
                    hashCode = hashCode * 59 + this.PolicyRunStatus.GetHashCode();
                if (this.PolicyRunStatusMessage != null)
                    hashCode = hashCode * 59 + this.PolicyRunStatusMessage.GetHashCode();
                if (this.PolicyRunId != null)
                    hashCode = hashCode * 59 + this.PolicyRunId.GetHashCode();
                if (this.ManifestBlobUrl != null)
                    hashCode = hashCode * 59 + this.ManifestBlobUrl.GetHashCode();
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
