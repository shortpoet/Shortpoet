export const routeMapper = function(paths) {
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


