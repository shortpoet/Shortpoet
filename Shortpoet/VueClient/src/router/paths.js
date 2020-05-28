/**
 * Define all of your application routes here
 * for more information on routes, see the
 * official documentation https://router.vuejs.org/en/
 */

const paths = [
  {
    path: '/',
    view: 'Landing'
  },
  {
    path: '/resume',
    view: 'Start'
  },
  {
    path: '/about',
    view: 'About'
  },
  {
    path: '/pdf',
    view: 'PDF'
  },
  {
    path: '/blog',
    view: 'Blog',
    props: true,
    children: [
      // {
      //   path: '/blog/:title',
      //   name: 'BlogArticle',
      //   props: (route) => ({ title: route.query.q })
      // },
      {
        path: '/blog/learning-to-unit-test-en',
        name: 'learning-to-unit-test-en',
        props: {
          language: 'en'
        }
      },
      {
        path: '/blog/learning-to-unit-test-es',
        name: 'learning-to-unit-test-es',
        props: {
          language: 'es'
        }
      }
    ]
  }
]

export default paths