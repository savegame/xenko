﻿// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using System;
using System.Collections.Generic;
using Xenko.Core.Annotations;
using Xenko.Core.IO;

namespace Xenko.Core.Assets
{
    public abstract class RawAssetImporterBase<TAsset> : AssetImporterBase
        where TAsset : Asset, IAssetWithSource, new()
    {
        /// <inheritdoc />
        public sealed override IEnumerable<Type> RootAssetTypes { get { yield return typeof(TAsset); } }

        /// <inheritdoc />
        [ItemNotNull]
        public sealed override IEnumerable<AssetItem> Import([NotNull] UFile rawAssetPath, AssetImporterParameters importParameters)
        {
            if (rawAssetPath == null) throw new ArgumentNullException(nameof(rawAssetPath));

            var asset = new TAsset { Source = rawAssetPath };
            // Creates the url to the raw asset
            var rawAssetUrl = new UFile(rawAssetPath.GetFileNameWithoutExtension());
            yield return new AssetItem(rawAssetUrl, asset);
        }
    }
}
