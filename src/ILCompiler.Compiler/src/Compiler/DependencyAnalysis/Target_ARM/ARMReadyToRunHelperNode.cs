// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

using Internal.TypeSystem;

using ILCompiler;
using ILCompiler.DependencyAnalysis.ARM;

namespace ILCompiler.DependencyAnalysis
{
    /// <summary>
    /// ARM specific portions of ReadyToRunHelperNode
    /// </summary>
    partial class ReadyToRunHelperNode
    {
        protected override void EmitCode(NodeFactory factory, ref ARMEmitter encoder, bool relocsOnly)
        {
            switch (Id)
            {
                case ReadyToRunHelperId.NewHelper:
                    {
                        TypeDesc target = (TypeDesc)Target;
                        ARMDebug.EmitHelperNYIAssert(factory, ref encoder, ReadyToRunHelperId.NewHelper);
                    }
                    break;

                case ReadyToRunHelperId.VirtualCall:
                    {
                        MethodDesc targetMethod = (MethodDesc)Target;
                        ARMDebug.EmitHelperNYIAssert(factory, ref encoder, ReadyToRunHelperId.VirtualCall);
                    }
                    break;

                case ReadyToRunHelperId.IsInstanceOf:
                    {
                        TypeDesc target = (TypeDesc)Target;
                        ARMDebug.EmitHelperNYIAssert(factory, ref encoder, ReadyToRunHelperId.IsInstanceOf);
                    }
                    break;

                case ReadyToRunHelperId.CastClass:
                    {
                        TypeDesc target = (TypeDesc)Target;
                        ARMDebug.EmitHelperNYIAssert(factory, ref encoder, ReadyToRunHelperId.CastClass);
                    }
                    break;

                case ReadyToRunHelperId.NewArr1:
                    {
                        TypeDesc target = (TypeDesc)Target;
                        ARMDebug.EmitHelperNYIAssert(factory, ref encoder, ReadyToRunHelperId.NewArr1);
                    }
                    break;

                case ReadyToRunHelperId.GetNonGCStaticBase:
                    {
                        MetadataType target = (MetadataType)Target;
                        ARMDebug.EmitHelperNYIAssert(factory, ref encoder, ReadyToRunHelperId.GetNonGCStaticBase);
                    }
                    break;

                case ReadyToRunHelperId.GetThreadStaticBase:
                    {
                        MetadataType target = (MetadataType)Target;
                        ARMDebug.EmitHelperNYIAssert(factory, ref encoder, ReadyToRunHelperId.GetThreadStaticBase);
                    }
                    break;

                case ReadyToRunHelperId.GetGCStaticBase:
                    {
                        MetadataType target = (MetadataType)Target;
                        ARMDebug.EmitHelperNYIAssert(factory, ref encoder, ReadyToRunHelperId.GetGCStaticBase);
                    }
                    break;

                case ReadyToRunHelperId.DelegateCtor:
                    {
                        DelegateCreationInfo target = (DelegateCreationInfo)Target;
                        ARMDebug.EmitHelperNYIAssert(factory, ref encoder, ReadyToRunHelperId.DelegateCtor);
                    }
                    break;

                case ReadyToRunHelperId.ResolveVirtualFunction:
                    {
                        MethodDesc targetMethod = (MethodDesc)Target;
                        ARMDebug.EmitHelperNYIAssert(factory, ref encoder, ReadyToRunHelperId.ResolveVirtualFunction);
                    }
                    break;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
