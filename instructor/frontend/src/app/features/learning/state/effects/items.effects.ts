import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, map, mergeMap, of, switchMap } from 'rxjs';
import { errorsEvents } from '../actions/errors.actions';
import {
  itemsCommands,
  itemsDocuments,
  itemsEvents,
} from '../actions/items.actions';
import { ItemEntity } from '../reducers/items.reducer';

@Injectable()
export class ItemsEffects {
  // add the new item
  // send that payload on the action to the API using a POST
  // when it comes the API, turn it into a itemsDocuments.item and send it to the reducers

  addItem$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(itemsEvents.itemCreationRequested),
      mergeMap(
        // track all the pending requests, merge them together into this code when you get a response.
        (
          a, // this is usually good for "non safe" operations (methods other than GET)
        ) =>
          this.client
            .post<ItemEntity>(
              'http://localhost:1340/learning-resources',
              a.payload,
            )
            .pipe(
              map((response) => itemsDocuments.item({ payload: response })),
              catchError((resp) => {
                return of(
                  errorsEvents.errorHappened({
                    message: 'Welp, that failed! Sorry',
                    innerError: resp,
                  }),
                );
              }),
            ),
      ),
    );
  });

  loadItems$ = createEffect(() => {
    // a1, .... a2,....... a3
    return this.actions$.pipe(
      ofType(itemsCommands.loadTheItems),
      switchMap(() =>
        // does not track requests - the last request is the one that will be handled.
        // not only doesn't track the earlier requests, it "cancels" then.
        // usually good for GET requests
        this.client
          .get<{ data: ItemEntity[] }>(
            'http://localhost:1340/learning-resources', // > 16.667ms
          )
          .pipe(
            map((response) => response.data),
            map((payload) => itemsDocuments.items({ payload })),
          ),
      ),
    );
  });
  constructor(private actions$: Actions, private client: HttpClient) {}
}
