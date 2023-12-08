module.exports = {
    root: true,
    env: { browser: true, es2020: true },
    rules: {
        'import/no-unused-vars': 'warn', // Warn about unused imports

        // Turn off default ESLint rule for unused vars and use the React-specific one
        'no-unused-vars': 'off',
        'react/jsx-uses-react': 'off', // Don't enforce React to be explicitly used in JSX


        // Ensure components are defined and handle unused React imports
        'react/jsx-no-undef': 'error',
        'react/react-in-jsx-scope': 'off',
        'react/jsx-uses-react': 'off',

        // ... existing rules ...
    },
    extends: [
        'eslint:recommended',
        'plugin:react/recommended',
        'plugin:react-hooks/recommended',

    ],
    ignorePatterns: ['dist', '.eslintrc.cjs'],
    parserOptions: { ecmaVersion: 'latest', sourceType: 'module' },
    settings: { react: { version: '18.2' } },
    plugins: ['react-refresh'],
    rules: {
        'react-refresh/only-export-components': [
            'warn',
            { allowConstantExport: true },
        ],
    },
};
