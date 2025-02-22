﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace BootstrapBlazor.Components;

/// <summary>
/// FullScreen 组件部分类
/// </summary>
[BootstrapModuleAutoLoader(ModuleName = "fullscreen")]
public class FullScreen : BootstrapModuleComponentBase
{
    /// <summary>
    /// DialogServices 服务实例
    /// </summary>
    [Inject]
    [NotNull]
    private FullScreenService? FullScreenService { get; set; }

    /// <summary>
    /// OnInitialized 方法
    /// </summary>
    protected override void OnInitialized()
    {
        base.OnInitialized();

        // 注册 FullScreen 弹窗事件
        FullScreenService.Register(this, Show);
    }

    private FullScreenOption? Option { get; set; }

    private async Task Show(FullScreenOption option)
    {
        Option = option;

        await InvokeVoidAsync("execute", Id, Option.Element.Context != null ? option.Element : Option.Id);
    }

    /// <summary>
    /// Dispose 方法
    /// </summary>
    /// <param name="disposing"></param>
    protected override async ValueTask DisposeAsync(bool disposing)
    {
        if (disposing)
        {
            FullScreenService.UnRegister(this);
        }

        await base.DisposeAsync(disposing);
    }
}
