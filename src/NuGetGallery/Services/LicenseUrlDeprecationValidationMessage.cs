﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Web;

namespace NuGetGallery
{
    /// <summary>
    /// A generic license url deprecation message that appends a "Learn more" documentation link to a given base message.
    /// </summary>
    public class LicenseUrlDeprecationValidationMessage : IValidationMessage
    {
        private readonly string DeprecationLink = $"<a href=\"{GalleryConstants.LicenseDeprecationUrl}\">{Strings.UploadPackage_LearnMore}.</a>";

        private readonly string _baseMessage;
        
        public LicenseUrlDeprecationValidationMessage(string basePlainTextMessage)
        {
            if (string.IsNullOrWhiteSpace(basePlainTextMessage))
            {
                throw new ArgumentException($"{nameof(basePlainTextMessage)} must be non-empty string", nameof(basePlainTextMessage));
            }

            _baseMessage = basePlainTextMessage;
            PlainTextMessage = $"{_baseMessage} {Strings.UploadPackage_LearnMore}: {GalleryConstants.LicenseDeprecationUrl}.";
        }

        public string PlainTextMessage { get; }

        public bool HasRawHtmlRepresentation => true;

        public string RawHtmlMessage
            => HttpUtility.HtmlEncode(_baseMessage) + " " + DeprecationLink;
    }
}