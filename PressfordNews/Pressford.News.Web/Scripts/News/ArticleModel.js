function Article(data) {
    var self = this;
    data = data || {};
    self.ArticleId = data.ArticleId;
    self.Title = ko.observable(data.Title || "");
    self.Content = ko.observable(data.Content || "");
    self.Author = data.Author || "";
    self.ArticleDate = data.ArticleDate;
    self.error = ko.observable();
    self.Comments = ko.observableArray();
    self.NumberOfLikes = ko.observable(data.NumberOfLikes);
    self.NumberOfComments = ko.observable(data.NumberOfComments);

    self.newCommentMessage = ko.observable();
    self.addComment = function () {
        var comment = new Comment();
        comment.ArticleId = self.ArticleId;
        comment.Message(self.newCommentMessage());
        return $.ajax({
            url: commentApiUrl + "Add",
            dataType: "json",
            contentType: "application/json",
            cache: false,
            type: 'POST',
            data: ko.toJSON(comment)
        })
       .done(function (result) {
           self.Comments.push(new Comment(result));
           self.newCommentMessage('');
       })
       .fail(function () {
           error('unable to add article');
       });


    }

    if (data.Comments) {
        var mappedComments = $.map(data.Comments, function (item) { return new Comment(item); });
        self.Comments(mappedComments);
    }
    self.toggleComment = function (item, event) {
        $(event.target).next().find('.publishComment').toggle();
    }

    return self;
}