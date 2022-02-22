export function addGiscus() {
	const giscus = document.createElement("script");
	giscus.setAttribute("src", "https://giscus.app/client.js");
	giscus.setAttribute("data-repo", "Jisu-Woniu/Blog");
	giscus.setAttribute("data-repo-id", "R_kgDOG4JZsQ");
	giscus.setAttribute("data-category", "Announcements");
	giscus.setAttribute("data-category-id", "DIC_kwDOG4JZsc4CBQ54");
	giscus.setAttribute("data-mapping", "pathname");
	giscus.setAttribute("data-reactions-enabled", "1");
	giscus.setAttribute("data-emit-metadata", "0");
	giscus.setAttribute("data-input-position", "top");
	giscus.setAttribute("data-theme", "light");
	giscus.setAttribute("data-lang", "zh-CN");
	giscus.setAttribute("crossorigin", "anonymous");
	giscus.setAttribute("async", "");
	document.getElementsByClassName("content")[0].appendChild(giscus);
}