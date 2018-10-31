import { Injectable } from '@angular/core';

declare var $: any;

/**
 * Maintains the communication to the SignalR Hub
 */
@Injectable({
  providedIn: 'root'
})
export class HubService {
  private connection: any;
  private proxy: any;

  /**
   * Connect to the hub
   * @param onActionRequested callback to handle incoming requests from the signalR hub.
   */
  connect(onActionRequested: (action: any) => void) {
    this.connection = $.hubConnection('http://localhost:8080/signalr');
    this.proxy = this.connection.createHubProxy('InteractionHub');

    this.proxy.on('ActionRequested', action => onActionRequested(action));

    this.connection.stateChanged(change => {
      if (change.newState === 4) {
        // state 4 = disconnected; this happens after several reconnect tries.
        // fake action "logout"... ok for a demo ;-)
        onActionRequested({ Name: 'logout' });
      }
      console.log('HUB CONNECTION - StateChanged', this.getStateChangeText(change), change);
    });

    this.connection
      .start()
      .done(info => {
        console.log('HUB CONNECTION - to signalr hub', info.url, 'using', info.transport.name);

        this.dispatchAction({
          name: 'requestLogin',
          arguments: ''
        });
      })
      .fail(() => console.log('HUB CONNECTION - to SignalR Hub failed.'));
  }

  /**
   * Dispatches an action to the hub, which will be broadcasted to the other clients
   * @param action action params as instruction for the receiver.
   */
  dispatchAction(action: any) {
    this.proxy.invoke('DispatchAction', action);
    console.log('>>> ActionDispatched', action);
  }

  private getStateChangeText(change: any) {
    for (const key in $.signalR.connectionState) {
      if ($.signalR.connectionState.hasOwnProperty(key)) {
        const value = $.signalR.connectionState[key];
        if (change.newState === value) {
          return key;
        }
      }
    }
    return 'unknown state';
  }
}
