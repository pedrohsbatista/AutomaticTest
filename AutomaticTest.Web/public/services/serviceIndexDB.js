const database = 'AutomaticTest';

export default {
    openConnection: function (objectStoreName) {
        return new Promise((success, error) => {
            let request = indexedDB.open(database, 1);

            request.onupgradeneeded = function (e) {
                let db = e.target.result;
                if (!db.objectStoreNames.contains(objectStoreName)) {
                    db.createObjectStore(objectStoreName, { keyPath: 'id' });
                }
            }

            request.onsuccess = function (e) {
                success(request.result);
            },

            request.onerror = function (e) {
                error(e.target.error.message);
            }
        })
    },
    openObjectStore: function (db, objectStoreName, mode) {
        let transaction = db.transaction([objectStoreName], mode);
        return transaction.objectStore(objectStoreName);
    },
    getAll: function (objectStoreName) {
        return new Promise((success, error) => {            
            this.openConnection(objectStoreName).then((db) => {
                let objectStore = this.openObjectStore(db, objectStoreName, "readonly");
                let request = objectStore.getAll();

                request.onsuccess = function (e) {
                    success(e.target.result);
                }

                request.onerror = function (e) {
                    error(e.target.error.message);
                }
            }).catch((exception) => {
                error(exception);
            });
        })
    },
    getById: function (objectStoreName, id) {
        return new Promise((success, error) => {
            this.openConnection(objectStoreName).then((db) => {
                let objectStore = this.openObjectStore(db, objectStoreName, "readonly");
                let request = objectStore.get(id);

                request.onsuccess = function (e) {                    
                    success(e.target.result);              
                }

                request.onerror = function (e) {
                    error(e.target.error.message);
                }
            }).catch((exception) => {
                error(exception);
            })
        })
    },
    post: function (objectStoreName, object) {
        object.id = this.setId();
        return new Promise((success, error) => {
            this.openConnection(objectStoreName).then((db) => {
                let objectStore = this.openObjectStore(db, objectStoreName, "readwrite");
                let request = objectStore.add(object);

                request.onsuccess = function (e) {
                    success();
                }

                request.onerror = function (e) {
                    error(e.target.error.message);
                }
            }).catch((exception) => {
                error(exception);
            });
        })
    },
    put: function (objectStoreName, object) {
        return new Promise((success, error) => {
            this.openConnection(objectStoreName).then((db) => {
                let objectStore = this.openObjectStore(db, objectStoreName, "readwrite");
                let request = objectStore.put(object);

                request.onsuccess = function (e) {
                    success();
                }

                request.onerror = function (e) {
                    error(e.target.error.message);
                }
            }).catch((exception) => {
                error(exception);
            })
        })
    },
    delete: function (objectStoreName, id) {
        return new Promise((success, error) => {
            this.openConnection(objectStoreName).then((db) => {
                let objectStore = this.openObjectStore(db, objectStoreName, "readwrite");
                let request = objectStore.delete(id);

                request.onsuccess = function (e) {
                    success();
                }

                request.onerror = function (e) {
                    error(e.target.error.message);
                }
            }).catch((exception) => {
                error(exception);
            });
        });
    },
    setId: function () {
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = Math.random() * 16 | 0,
                v = c == 'x' ? r : (r & 0x3 | 0x8);
            return v.toString(16);
        });
    }
}