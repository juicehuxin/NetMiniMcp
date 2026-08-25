# NetMiniMcp

一个使用 ASP.NET Core 和官方 .NET MCP SDK 实现的最小 MCP 服务。

## MCP 工具

`calculate_statistics` 接收 `numbers` 数组，返回：

- `maximum`：最大值
- `minimum`：最小值
- `count`：数量
- `sum`：求和
- `average`：平均值

输入示例：

```json
{
  "numbers": [1.5, 2, -3, 4.5]
}
```

输出示例：

```json
{
  "maximum": 4.5,
  "minimum": -3,
  "count": 4,
  "sum": 5,
  "average": 1.25
}
```

空数组、`NaN` 和无穷大输入会被拒绝。

## 启动

```powershell
dotnet run --urls http://127.0.0.1:5050
```

健康检查：`http://127.0.0.1:5050/healthz`

MCP Streamable HTTP 地址：`http://127.0.0.1:5050/mcp`

## Cursor MCP 配置示例

在 MCP 服务器配置中选择 **Streamable HTTP**，URL 填写：

```text
http://127.0.0.1:5050/mcp
```

本项目只用于演示，未加入鉴权或生产部署配置。

## 生产部署地址约定

多个独立 MCP 项目统一使用以下公网地址格式：

```text
https://<项目名>.mcp.huxin.fun/mcp
```

本项目的生产地址为：

```text
https://netmini.mcp.huxin.fun/mcp
```

示例：

```text
https://nuonuo.mcp.huxin.fun/mcp
https://pc-investigate.mcp.huxin.fun/mcp
```

服务应用内仍保持 MCP 路径为 `/mcp`；Caddy 按子域名将请求反向代理到对应项目容器。

生产环境的 Bearer Token 仅保存在服务器，不提交到仓库。需要在本机查看本项目 Token 时执行：

```bash
ssh juice 'sudo awk -F= "/^NET_MINI_MCP_TOKEN=/{print \$2}" /root/food/.env'
```

请勿将命令输出写入文档、日志或提交到 Git。
