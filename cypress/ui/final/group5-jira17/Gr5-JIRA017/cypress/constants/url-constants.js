export const BASE_URL = 'https://unsplash.com'
export const LOGIN_URL = `${BASE_URL}/login`
export const COLLECTION_URL ={
    specificCollection(collection_id){
        return `/collections/${collection_id}`
    }
}
export const LIKE_URL ={
    like(username){
        return `${username}/likes`
    }
}