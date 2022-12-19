export const ApiConstants ={
    postCollection(url,title, description){
        return `${url}/collections?title=${title}&description=${description}&private=true`;
    },
    postPhoto(url,collection_id,photo_id)
    {
        return `${url}/collections/${collection_id}/add?collection_id=${collection_id}&photo_id=${photo_id}`
    },
    deleteCollection(url,collectionId)
    {
        return `${url}/collections/${collectionId}`;
    },
    getLikedPhotos(url,userName)
    {
        return `${url}/users/${userName}/likes`
    },
    unLikePhoto(url,photo_id)
    {
        return `${url}/photos/${photo_id}/like`
    },
    randomPhoto(url,photo_count)
    {
        return `${url}/photos/random?count=${photo_count}`
    },
    likePhoto(url,photo_id)
    {
        return `${url}/photos/${photo_id}/like`
    },
    getRandomPhoto(url){
        return `${url}/photos/random`
    },
    getPhotoDownloadLink(url){
        return `${url}`
    }
}