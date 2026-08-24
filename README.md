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
