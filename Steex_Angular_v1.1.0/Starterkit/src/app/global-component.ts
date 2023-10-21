export const GlobalComponent = {
    // Api Calling
    API_URL : 'https://localhost:44349/',
    // API_URL : 'http://127.0.0.1:3000/',
    headerToken : {'Authorization': `Bearer ${localStorage.getItem('token')}`},

    // Auth Api
    AUTH_API:"https://localhost:44349/",
    CLIENT_ID: "XPCPlatform_App",
    CLIENT_SECRET: "1q2w3e*",
    // AUTH_API:"http://127.0.0.1:3000/auth/",

    
    // Products Api
    product:'apps/product',
    productDelete:'apps/product/',

    // Orders Api
    order:'apps/order',
    orderId:'apps/order/',

    // Customers Api
    customer:'apps/customer',
}