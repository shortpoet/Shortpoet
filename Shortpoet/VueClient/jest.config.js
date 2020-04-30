module.exports = {
  // preset: '@vue/cli-plugin-unit-jest',
  // https://github.com/Swrve/create-react-app/commit/ddf46bd89431b9ea60d2b93b7112b15c7c324b23
  // roots: ['<rootDir>/src', '<rootDir>/__mocks__'],
  // collectCoverageFrom: ['src/**/*.{js,jsx,ts,tsx}', '!src/**/*.d.ts'],
  // https://github.com/vuejs/vue-cli/issues/1584
  moduleFileExtensions: ['js', 'jsx', 'json', 'vue'],
  transform: {
    '^.+\\.vue$': 'vue-jest',
    '.+\\.(css|styl|less|sass|scss|png|jpg|ttf|woff|woff2)$':
      'jest-transform-stub',
    '^.+\\.(js|jsx)?$': 'babel-jest'
  },
  modulePaths: [
    "<rootDir>"
  ],
  moduleNameMapper: {
    '^@/(.*)$': '<rootDir>/src/$1'
  },
  snapshotSerializers: ['jest-serializer-vue'],
  testMatch: [
    '<rootDir>/(tests/unit/**/*.spec.(js|jsx|ts|tsx)|**/__tests__/*.(js|jsx|ts|tsx))',
    '**/__tests__/*.{j,t}s?(x)',
    '**/tests/unit/**/*.spec.{j,t}s?(x)',
    '<rootDir>/__mocks__',

    '<rootDir>/tests/unit/**/*.spec.(js|jsx|ts|tsx)|**/__tests__/*.(js|jsx|ts|tsx)'
  ],
  // transformIgnorePatterns: ['<rootDir>/node_modules/']
}
