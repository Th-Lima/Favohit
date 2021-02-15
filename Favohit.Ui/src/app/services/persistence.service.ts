import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PersistenceService {

  constructor() { }

  set(key: string, data: any){
    try{
        localStorage.setItem(key, JSON.stringify(data));
    }catch(e){
        console.error('Error saving to localstorage', e);
    }
  }

  get(key: string){
      try{
         return JSON.parse(localStorage.getItem(key));
      }catch (e){
          console.error('Error getting data from localstorage');
          return null;
      }
  }

  remove(key: string){
      localStorage.removeItem(key);
  }

  exists(key: string): boolean{
      const data = localStorage.getItem(key);
      return !!data;
  }

}
