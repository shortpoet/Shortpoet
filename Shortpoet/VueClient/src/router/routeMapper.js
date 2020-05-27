export const routeMapper = function(paths) {
  return paths
    .map(path => {
      return {
        name: path.name || path.view,
        path: path.path,
        component: path.view ? resolve => import(`@/views/${path.view}.vue`).then(resolve) : resolve => import(`@/components/Blog/BlogArticle.vue`).then(resolve),
        children: path.children ? routeMapper(path.children) : []
      }
    })
    // catch-all route
    // .concat([{path: '*', redirect: '/resume'}])
}
export const mockRouteMapper = function(paths) {
  return paths
    .map(path => {
      return {
        name: path.name || path.view,
        path: path.path,
        component: resolve => import(`@/views/${path.view}.vue`).then(resolve)
      }
    })
    // catch-all route
    // .concat([{path: '*', redirect: '/resume'}])
}


