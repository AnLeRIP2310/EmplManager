﻿


const edited_span = "&nbsp;<span  class='italic mess_edited'>(đã chỉnh sửa)</span>";

$(function () {

    hubProxy.on('MessageEdited', async function (json_data) {
        console.log(json_data);
        json_data = JSON.parse(json_data);
        Saved_Messages[json_data.id].Content = json_data.new_content;
        $(`.chat-main__item[message_id=${json_data.id}]`).find(".mess_content:not(.toRemove)").html(wrapLinksIntoAnchorTags(json_data.new_content).replaceAll("\n","<br>") + edited_span);
    });
    hubProxy.on('ReceiveMessage', async function (message) {

        message = JSON.parse(message);

      
        Saved_Messages[message.Id] = message;


        let last_read_message = getLastReadMessage();

        latest_message_id = message.Id;
    
        let can_render = latest_message_id == findLatestMessageId() + 1;
       
        if (can_render) {
          
            loadedbottom = true;
            await renderMessage(message,true);
            reloadTimegaps(message.Id);
        }

        if (can_render && (Users.CLIENT_USER.Id == message.UserId || getScrollPos() < scroll.clientHeight / 2 && focused)) {

            console.log("Scrolled bottom on new message....");
            scrollBottom();
            setTimeout(scrollBottom,0);

        }
        if (message.UserId == Users.CLIENT_USER.Id) {
            setLastRenderedMessageCache(message.Id);
        }
 
        if (Users.CLIENT_USER.Id != message.UserId ) {


       
            let new_messages_ever_since = latest_message_id - last_read_message.Id;
            let old_bar_exists = $("#markasread_active").length > 0;

    
            if (!last_unread_message_id) {
                let new_bar = old_bar_exists ? $("#markasread_active") : new_messages_template.clone();
                new_bar.attr("id", "markasread_active");

                var insert_after_ele = $(".chat-main__list").find(`.chat-main__item[message_id=${last_read_message.Id}]`);
                if (insert_after_ele.length != 0) {
                    new_bar.insertAfter(insert_after_ele);

                }
               
                unread_messages_ele.css("display", "");
                let n_date = new Date(message.AtCreate);
     
                let date = FormatFuncs["_timestr_"]({AtCreate: n_date});


            

                unread_messages_ele.find(".unread_notif_message").text(`Bạn có ${new_messages_ever_since} tin nhắn chưa đọc kể từ ${date}`);

                last_unread_message_id = last_read_message.Id;
            }
            else {
                unread_messages_ele.css("display", "");
             
                let new_messages_ever_since = latest_message_id - last_unread_message_id;

                var old_text = unread_messages_ele.find(".unread_notif_message").text();
      
                var new_str = old_text.replace(/\d+/, new_messages_ever_since);
      
                unread_messages_ele.find(".unread_notif_message").text(new_str);

            }




          
        }

    });

    hubProxy.on('MessageDeleted', async function (message) {
        DeleteMessage(message);
    });

    hubProxy.on('UpdateReaction', async function (json) {

        var data = JSON.parse(json);

        if (bound_reaction_lists[data.Message_Id]) {
            console.log(data.Reaction_Ids);
            bound_reaction_lists[data.Message_Id] = data.Reaction_Ids;
        }
        UpdateMessageReaction(data);
    });


    function connect() {
        connection.start()
            .done(function () {
                console.log('SignalR connection started.');
            })
            .fail(function (error) {

                console.log('Error starting SignalR connection:', error);
                setTimeout(connect, 1000);
            });


    }
    connect();
});