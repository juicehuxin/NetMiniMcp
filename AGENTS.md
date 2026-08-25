# NetMiniMcp 开发指南

## 项目概览

- .NET 8 ASP.NET Core MCP 服务，使用官方 `ModelContextProtocol` SDK。
- 入口为 `Program.cs`；MCP 服务注册与端点映射位于 `Mcp/`。
- MCP 工具位于 `Mcp/Tools/`，通过 `[McpServerToolType]` 和 `[McpServerTool]` 暴露。

## 本地运行与验证

```bash
dotnet run --urls http://127.0.0.1:5050
curl http://127.0.0.1:5050/healthz
dotnet build
```

- 应用内 MCP 端点固定为 `/mcp`。
- 修改工具或端点后，至少运行 `dotnet build`；本仓库当前没有测试项目。

## 公网部署约定

多个独立 MCP 项目统一使用：

```text
https://<项目名>.mcp.huxin.fun/mcp
```

本项目生产地址为：`https://netmini.mcp.huxin.fun/mcp`。

Caddy 根据项目子域名将请求反向代理到对应容器；不要改变应用内的 `/mcp` 路径，也不要直接向公网映射应用容器端口。

## 变更原则

- 保持变更最小，只修改当前需求所必需的文件。
- 保持现有 MCP 接口、工具名称与输入输出格式兼容，除非需求明确要求变更。
- 不将凭据、Token 或服务器私密配置提交到仓库。
