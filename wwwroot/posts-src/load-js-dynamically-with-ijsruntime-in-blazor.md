# 在 Blazor 中使用 `IJSRuntime` 动态加载 JavaScript 脚本

JavaScript 作为前端项目重要的脚本语言，在前端发挥着非常重要的作用。网页中嵌入 JavaScript 代码非常简单：

```html
<script>
    alert("Hello World!");
</script>
```

正因如此，许多页面组件采用 JS 脚本实现动态加载。如本博客中采用的 [giscus 评论系统](https://giscus.app)。

然而，Blazor 中的 JS 脚本加载与其他基于 JS 开发的项目有很大不同：

- `<script>` 标签不可出现在控件代码（`.razor` 文件）中
- 在 `index.html` 
