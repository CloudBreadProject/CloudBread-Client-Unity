/**
 * Copyright (c) 2014-present, Facebook, Inc. All rights reserved.
 *
 * You are hereby granted a non-exclusive, worldwide, royalty-free license to use,
 * copy, modify, and distribute this software in source code or binary form for use
 * in connection with the web services and APIs provided by Facebook.
 *
 * As with any software that integrates with the Facebook platform, your use of
 * this software is subject to the Facebook Developer Principles and Policies
 * [http://developers.facebook.com/policy/]. This copyright notice shall be
 * included in all copies or substantial portions of the software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
 * FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
 * COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
 * IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
 * CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

namespace Facebook.Unity
{
    using System;
    using System.Collections.Generic;

    internal class AppLinkResult : ResultBase, IAppLinkResult
    {
        public AppLinkResult(string result) : base(result)
        {
            if (this.ResultDictionary != null)
            {
                string url;
                if (this.ResultDictionary.TryGetValue<string>(Constants.UrlKey, out url))
                {
                    this.Url = url;
                }

                string targetUrl;
                if (this.ResultDictionary.TryGetValue<string>(Constants.TargetUrlKey, out targetUrl))
                {
                    this.TargetUrl = targetUrl;
                }

                string refStr;
                if (this.ResultDictionary.TryGetValue<string>(Constants.RefKey, out refStr))
                {
                    this.Ref = refStr;
                }

                IDictionary<string, object> argumentBundle;
                if (this.ResultDictionary.TryGetValue<IDictionary<string, object>>(Constants.ExtrasKey, out argumentBundle))
                {
                    this.Extras = argumentBundle;
                }
            }
        }

        public string Url { get; private set; }

        public string TargetUrl { get; private set; }

        public string Ref { get; private set; }

        public IDictionary<string, object> Extras { get; private set; }
    }
}
